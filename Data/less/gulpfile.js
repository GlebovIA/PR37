const gulp = require('gulp');
const less = require('gulp-less');
const concat = require('gulp-concat');
const sourcemaps = require('gulp-sourcemaps');
const autoprefixer = require('gulp-autoprefixer');
gulp.task('less', function() {
  return gulp.src('src/less/**/*.less')
    .pipe(gulpIf(isDevelopment, sourcemaps.init()))
    .pipe(autoprefixer({
        browsers: ['last 2 versions'],
    cascade: false
        }))
    .pipe(less())
    .pipe(concat('Style.css'))
    .pipe(gulpIf(sourcemaps.write()))
    .pipe(gulp.dest('wwwroot/css'))
 });
gulp.task('default', gulp.parallel('less'));
function watch_dev() {
    watch('./src/styles/Style.css', styles).on(
        'change',
        browserSync.reload
    )
}
exports.default = parallel(
    styles,
    scripts,
    pages,
    watch_dev
)