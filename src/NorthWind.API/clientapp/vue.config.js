const path = require('path');
const { VueLoaderPlugin } = require('vue-loader')

module.exports = {
    outputDir: path.resolve('../wwwroot/bundles/'),
    filenameHashing: false,
    runtimeCompiler: true,
}