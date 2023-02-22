module.exports = class TimeStampPlugin {
  format = Intl.DateTimeFormat('de', {
    hour: '2-digit',
    minute: '2-digit',
    second: '2-digit',
  });
  lastStart = new Date();
  apply(compiler) {
    compiler.hooks.done.tap('log on done', () => {
      const now = new Date();
      const dt = now.getTime() - this.lastStart.getTime();

      setTimeout(
        () => console.log(`\n[${this.format.format(now)}]. Compiled successfully (${dt}ms), waiting for file changes...\n`),
        10
      );
    });

    compiler.hooks.beforeCompile.tap('log on beforeCompile', () => {
      this.lastStart = new Date();

      setTimeout(() => console.log(`\n[${this.format.format(this.lastStart)}]. Compilation started...\n`), 10);
    });
  }
};
