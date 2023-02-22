const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const TimeStampPlugin = require('./webpack/plugins/timestamp-plugin.js');

/**
 * Der Modus für die Ausführung. Entweder production oder development.
 */
const mode = process.env.NODE_ENV || 'development';
const isDev = mode === 'development';

console.log(`Starting webpack, mode is ${mode}.`);

const base = './resources';
const ts = base + '/ts';
const scss = base + '/scss';

const cssLoaders = [
  MiniCssExtractPlugin.loader,
  {
    loader: 'css-loader',
    options: { sourceMap: isDev },
  },
  { loader: 'postcss-loader' },
];

/**
 * Die Optionen für webpack.
 */
module.exports = () => {
  return {
    entry: {
      index: [`${ts}/index.ts`, `${scss}/index.scss`],
    },
    output: {
      path: path.resolve('./public'),
      filename: isDev ? '[name].bundle.js' : '[name].[contenthash].bundle.js',
      assetModuleFilename: 'assets/[hash][ext]',
      // clean: isProd(),
    },
    // devtool erzeugt Source maps, wenn der Entwicklungsmodus aktiv ist.
    devtool: mode === 'development' ? 'inline-source-map' : undefined,
    // Plugins ändern das Verhalten von webpack
    plugins: [
      // TimeStampPlugin will print a timestamp if a build has finished.
      new TimeStampPlugin(),
      // MiniCssExtractPlugin will create styles.
      new MiniCssExtractPlugin({
        filename: isDev ? '[name].bundle.css' : '[name].[contenthash].bundle.css',
      }),
    ],
    module: {
      rules: [
        {
          // TypeScript-Dateien.
          test: /\.tsx?$/,
          use: {
            loader: 'ts-loader',
            options: {
              configFile: isDev ? 'tsconfig.json' : 'tsconfig.prod.json',
              projectReferences: true,
            },
          },
          exclude: /node_modules/,
        },
        {
          // SCSS-Stylesheets
          test: /\.scss$/,
          use: [
            ...cssLoaders,
            {
              loader: 'sass-loader',
              options: {
                sassOptions: {
                  includePaths: [path.resolve('./resources/scss/')],
                },
              },
            },
          ],
          exclude: [/node_modules/],
        },
        {
          // CSS-Stylesheets
          test: /\.css?$/,
          use: [...cssLoaders],

          exclude: [/node_modules/],
        },
        {
          // Images
          test: /\.(png|jpg|jpeg|svg)/,
          type: 'asset/resource',
          generator: {
            filename: 'assets/img/[name][contenthash][ext]',
          },
        },
        {
          // Fonts
          test: /\.(woff|woff2|eot|ttf|otf)$/i,
          type: 'asset/resource',
          generator: {
            filename: 'assets/fonts/[name][contenthash][ext]',
          },
        },
      ],
    },
    mode,
    resolve: {
      extensions: ['.tsx', '.ts', '.js', '.png', 'scss', 'css'],
    },
    optimization: {
      usedExports: true,
    },
  };
};
