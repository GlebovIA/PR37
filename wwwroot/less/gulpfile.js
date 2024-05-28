"use strict";

var gulp = require("gulp"),
    less = require("gulp-less");

var paths = {
    webroot: "./wwwroot/"
};
gulp.task("less", function () {
    return gulp.src('less/styles.less')
        .pipe(less())
        .pipe(gulp.dest(paths.webroot + '/css'))
});