/// <reference path="wwwroot/lib/jquery/dist/jquery.min.js" />
/// <reference path="wwwroot/lib/jquery/dist/jquery.js" />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),concat=require('gulp-concat'),uglifycss=require('gulp-uglifycss'),del=require('del');

gulp.task('default', ['cleanLib', 'copyCSS', 'copyJS']);

gulp.task('copyCSS', function () {
    // place code for your default task here
    gulp.src(['wwwroot/lib/bootstrap/dist/css/bootstrap.css'])
        .pipe(uglifycss())
        .pipe(concat('site.css'))
        .pipe(gulp.dest('wwwroot/lib'));
});

gulp.task('copyJS', function () {
    // place code for your default task here
    gulp.src(['wwwroot/lib/jquery/dist/jquery.js'])
        .pipe(concat('third-party.js'))
        .pipe(gulp.dest('wwwroot/lib'));
});

gulp.task('cleanLib', function () {
    // place code for your default task here
    return del(['wwwroot/lib/third-party.js', 'wwwroot/lib/site.css']);
});

