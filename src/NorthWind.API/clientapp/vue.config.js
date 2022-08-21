const path = require('path')

module.exports = {
    transpileDependencies: [
        'vuetify',
        'vuex-module-decorators'
    ],
    // filenameHashing: false,
    // outputDir: path.resolve('../wwwroot/bundles/'),
    // chainWebpack: config => {
    //     config.plugins.delete('html')
    //     config.plugins.delete('preload')
    //     config.plugins.delete('prefetch')
    // }
}
