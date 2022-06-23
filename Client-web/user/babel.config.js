module.exports = function(api) {
    return {
        plugins: ['macros'],
        addBabelPreset("@babel/preset-react"),
        addExternalBabelPlugin('@babel/plugin-proposal-class-properties'),
    }
}