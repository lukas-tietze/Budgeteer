module.exports = {
    "env": {
        "browser": true,
        "es2021": true,
    },
    "plugins": [
      '@typescript-eslint',
    ],
    "extends":[
      "eslint:recommended",
      "plugin:@typescript-eslint/recommended",
    ],
    "overrides": [
        {
            "env": {
                "node": true,
            },
            "files": [
                ".eslintrc.{js,cjs}",
            ],
            "parserOptions": {
                "sourceType": "script",
            }
        }
    ],
    "parser": '@typescript-eslint/parser',
    "parserOptions": {
        "ecmaVersion": "latest",
        "sourceType": "module",
    },
    "rules": {
      "no-inline-comments": "warn",
      "no-warning-comments": "warn",
      '@typescript-eslint/ban-ts-comment': [
        'error',
        {
          'ts-ignore': 'allow-with-description'
        },
      ],
    },
    root: true,
};
