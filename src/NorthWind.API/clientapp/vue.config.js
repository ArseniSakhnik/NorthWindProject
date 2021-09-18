const path = require('path');
const {VueLoaderPlugin} = require('vue-loader')

module.exports = {
    outputDir: path.resolve('../wwwroot/bundles/'),
    filenameHashing: false,
    chainWebpack: config => {
        config.plugins.delete('html')
        config.plugins.delete('preload')
        config.plugins.delete('prefetch')
        config.module
            .rule('images')
            .use('url-loader')
            .loader('url-loader')
            .tap(options => Object.assign(options, {limit: 10240}))
    },
    runtimeCompiler: true,
    configureWebpack: {
        module: {
            rules: [
                {
                    test: /\.(woff(2)?|ttf|eot|svg)(\?v=\d+\.\d+\.\d+)?$/,
                    use: {
                        loader: 'file-loader',
                        options: {
                            name: '[hash]-[name].[ext]',
                            outputPath: '../fonts/',
                            publicPath: './bundles/fonts/'
                        }
                    }
                },
            ]
        }
    }
}