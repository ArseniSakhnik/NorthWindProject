﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.Internal;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.API.Models;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Entities.Purchase;
using NorthWindProject.Application.Entities.Service;
using Spire.Doc;
using Spire.Doc.Documents;

namespace NorthWindProject.Application.Features.ExportDocument.Query
{
    public class ExportPurchaseQuery : IRequest<FileModel>
    {
        public string ServiceName { get; set; }

        #region Загрузка когда заявка уже создана в бд

        public int PurchaseId { get; set; }

        #endregion

        #region Загрузка когда заявка ещё не создана в бд

        public Entities.Purchase.Purchase Purchase { get; set; }

        #endregion

        public ExportPurchaseQuery(string serviceName, int purchaseId)
        {
            ServiceName = serviceName;
            PurchaseId = purchaseId;
        }

        public ExportPurchaseQuery(string serviceName, 
            Entities.Purchase.Purchase purchase)
        {
            ServiceName = serviceName;
            Purchase = purchase;
        }
    }

    public class ExportPurchaseQueryHandler : IRequestHandler<ExportPurchaseQuery, FileModel>
    {
        private readonly AppDbContext _context;

        public ExportPurchaseQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FileModel> Handle(ExportPurchaseQuery request, CancellationToken cancellationToken)
        {
            byte[] documentContent;

            if (request.Purchase is null)
            {
                documentContent = await _context.Purchases
                    .Where(purchase => purchase.Id == request.PurchaseId)
                    .SelectMany(purchase => purchase.Service.DocumentServices)
                    .Select(document => document.Content)
                    .SingleOrDefaultAsync(cancellationToken);
            }
            else
            {
                documentContent = request.Purchase.Service.DocumentServices
                    .Select(document => document.Content)
                    .SingleOrDefault();
            }


            List<FieldPurchase> purchaseFields;

            if (request.Purchase is null)
            {
                purchaseFields = await _context.FieldPurchases
                    .Where(field => field.PurchaseId == request.PurchaseId)
                    .Include(field => field.FieldService)
                    .ToListAsync(cancellationToken);
            }
            else
            {
                purchaseFields = request.Purchase.Fields;
            }


            var purchaseUserName = await _context.Users
                .Where(user => user.Purchases.Any(purchase => purchase.Id == request.PurchaseId))
                .Select(user => $"{user.UserName} {user.Surname} {user.MiddleName}")
                .SingleOrDefaultAsync(cancellationToken);

            await using var stream = new MemoryStream(documentContent);
            var document = new Document(stream);
            var booksMarkNavigator = new BookmarksNavigator(document);

            var bookMarks = booksMarkNavigator.Document.Bookmarks;
            
            foreach (Bookmark bookMark in bookMarks)
            {
                booksMarkNavigator.MoveToBookmark(bookMark.Name);
                
                var fieldValue = purchaseFields
                    .Where(field => field.FieldService.BookMarkName.Contains(bookMark.Name))
                    .Select(field => field.Value)
                    .FirstOrDefault() ?? "";
                
                booksMarkNavigator.InsertText(fieldValue, true);
            }

            document.SaveToStream(stream, FileFormat.Doc);

            return new FileModel
            {
                Name = $"{request.ServiceName} {purchaseUserName}",
                Content = stream.ToArray()
            };
        }
    }
}