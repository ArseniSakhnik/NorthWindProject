﻿using System.Collections.Generic;
using NorthWindProject.Application.Entities.Services.BaseService;
using NorthWindProject.Application.Enums;

namespace NorthWindProject.Application.Entities.Services
{
    public class Service
    {
        public ServicesEnum Id { get; set; }
        
        public List<BasePurchase> Purchases { get; set; }
        public List<DocumentService.DocumentService> DocumentServices { get; set; }
    }
}