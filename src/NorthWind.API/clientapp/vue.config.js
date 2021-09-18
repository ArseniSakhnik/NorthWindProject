const path = require('path');
const {VueLoaderPlugin} = require('vue-loader')

module.exports = {
    outputDir: path.resolve('../wwwroot/bundles/'),
    filenameHashing: false,
    runtimeCompiler: true,
    configureWebpack: {
        module: {
            rules: [
                {
                    test: /\.(png|jpg|gif)$/,
                    use: {
                        loader: 'url-loader',
                        options: {
                            esModule: false,
                            limit: 2048,
                            name: '[hash]-[name].[ext]',
                            outputPath: '../img/',
                            publicPath: './bundles/img/'
                        }
                    }
                },
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
                // {
                //     test: /\.vue$/,
                //     include: path.resolve(__dirname, './src/'),
                //     loader: 'vue-loader'
                // },
                // {
                //     test: /\.(css|scss)$/,
                //     use: ['style-loader', 'css-loader','sass-loader']
                // },
            ]
        }
    }
}