const { defineConfig } = require("eslint-define-config");

module.exports = defineConfig({
    root: true,
    env: {
        browser: true,
        es2020: true,
    },
    extends: [
        "eslint:recommended",
        "prettier",
        "plugin:@typescript-eslint/recommended",
        "plugin:react-hooks/recommended",
    ],
    ignorePatterns: ["dist", ".eslintrc.cjs"],
    parser: "@typescript-eslint/parser",
    plugins: ["react-refresh"],
    rules: {
        "arrow-parens": ["error", "as-needed"],
        "capitalized-comments": [
            "error",
            "always",
            {
                ignorePattern: "jscpd|cspell",
            },
        ],
        "id-length": [
            "error",
            {
                exceptions: ["_", "a", "b", "x", "y"],
            },
        ],
        "max-lines-per-function": ["error", { max: 100 }],
        "max-params": ["error", { max: 10 }],
        "max-statements": ["error", { max: 25 }],
        "react-refresh/only-export-components": [
            "warn",
            {
                allowConstantExport: true,
            },
        ],
        /*
         * For "no-restricted-syntax" use
         * https://typescript-eslint.io/play
         * https://astexplorer.net/
         * https://ts-ast-viewer.com/
         * https://github.com/typescript-eslint/typescript-eslint/issues/5863
         */
        "no-restricted-syntax": [
            "error",
            {
                message: "Do not use 'React` namespace, explicitly import types you need!",
                selector: "TSTypeReference > TSQualifiedName > Identifier[name='React']",
            },
        ],
        "no-ternary": "off",
        "no-undefined": "off",
        "no-unused-vars": ["errors", { exceptions: ["_"] }],
        "no-void": ["error", { allowAsStatement: true }],
        "no-warning-comments": "off",
        "one-var": "off",
        "padding-line-between-statements": "off",
        "spaced-comment": "off",
    },
});
