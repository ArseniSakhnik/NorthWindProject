const path = require('path');

module.exports = {
    outputDir: path.resolve('../wwwroot/bundles/'),
    filenameHashing: false,
    chainWebpack: config => {
        config.plugins.delete('html')
        config.plugins.delete('preload')
        config.plugins.delete('prefetch')
        // config.module
        //     .rule('images')
        //     .use('file-loader')
        //     .loader('file-loader')
        //     .tap(options => {
        //         options = {
        //             name: 'assets/backgrounds/[name].[ext]'
        //         }
        //         return options
        //     })
        //     .end()
        //Загрузка пикчи с сервера?
        // config.module
        //     .rule('images')
        //     .use('file-loader')
        //     .loader('file-loader')
        //     .tap(options => Object.assign(options, {limit: 10240}))

        // config.module
        //     .rule("fonts")
        //     .test(/\.(ttf|otf|eot|woff|woff2)$/)
        //     .use("url-loader")
        //     .loader("url-loader")
        //     .tap(options => {
        //         options = {
        //             // limit: 10000,
        //             name: '/fonts/[name].[ext]',
        //         }
        //         return options
        //     })
        //     .end()
    },
    // runtimeCompiler: true,
    // configureWebpack: {
    //     module: {
    //         rules: [
    //             {
    //                 test: /\.(woff(2)?|ttf|eot|svg)(\?v=\d+\.\d+\.\d+)?$/,
    //                 use: {
    //                     loader: 'file-loader',
    //                     options: {
    //                         name: '[hash]-[name].[ext]',
    //                         outputPath: '../font/',
    //                         publicPath: './bundles/fonts/'
    //                     }
    //                 }
    //             },
    //         ]
    //     }
    // }
}