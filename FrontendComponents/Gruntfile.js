/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/

module.exports = function (grunt) {
    require('jit-grunt')(grunt);

    grunt.loadNpmTasks('grunt-contrib-concat');

    grunt.initConfig({
        less: {
            development: {
                options: {
                    compress: true,
                    yuicompress: true,
                    optimization: 2
                },
                files: {
                    "../Sito/css/pifferitamburi.css": ["./styles/less/pifferitamburi.less"] // destination file and source file
                }
            }
        },
        watch: {
            styles: {
                files: ['less/**/*.less'], // which files to watch
                tasks: ['less'],
                options: {
                    nospawn: true
                }
            }
        },
        concat: {
            options: {
                separator: ";"
            },
            dist: {
                src: ['scripts/custom/pifferi.js'],
                //src: ['scripts/bootstrap/bootstrap.js', 'scripts/jquery/jquery.js'],
                dest: '../Sito/js/pifferi.js'
            }
        }
    });

    grunt.registerTask('default', ['less', 'watch']);
};