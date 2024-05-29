var gulp = require('gulp');
gulp.task('default', function () {
    var gulp = require('gulp'),
        less = require('gulp-less');

    gulp.task('less', function () {
        gulp.src('./Data/less/**/*.less')
            .pipe(less())
            .pipe(gulp.dest('./wwwroot/css/Style.css'));
    });

    gulp.task('default', function () {
        console.log("Completed");
    });
});