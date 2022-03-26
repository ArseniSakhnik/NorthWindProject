const path = require('path')

module.exports = {
    transpileDependencies: [
        'vuetify',
        'vuex-module-decorators'
    ],
    outputDir: path.resolve('../wwwroot/bundles/'),
    filenameHashing: false,
    // chainWebpack: config => {
    //     config.plugins.delete('html')
    //     config.plugins.delete('preload')
    //     config.plugins.delete('prefetch')
    // }
}
