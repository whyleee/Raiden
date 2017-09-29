const path = require('path')
const webpack = require('webpack')
const dest = 'wwwroot/dist'

module.exports = {
  entry: {
    app: './static/app.js'
  },
  output: {
    filename: '[name].js',
    path: path.resolve(__dirname, dest),
    publicPath: '/dist/'
  },
  module: {
    rules: [
      { test: /\.css$/, use: [ 'style-loader', 'css-loader' ] }
    ]
  },
  plugins: [
    new webpack.ProvidePlugin({
      $: 'jquery',
      jQuery: 'jquery',
      'window.jQuery': 'jquery',
      Popper: ['popper.js', 'default']
    }),
    new webpack.optimize.CommonsChunkPlugin({
      name: 'vendor',
      chunks: ['app'],
      minChunks(module) {
        return module.context && (/(node_modules)/).test(module.context)
      }
    }),
    new webpack.SourceMapDevToolPlugin({
      filename: '[file].map',
      moduleFilenameTemplate: path.relative(dest, '[resourcePath]'),
      exclude: ['vendor.js']
    })
  ]
}
