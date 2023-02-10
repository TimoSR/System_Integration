"use strict";
exports.__esModule = true;
var fs = require("fs");
fs.readFile('../files/text_file.txt', 'utf-8', function (err, data) {
    if (err) {
        console.log(err);
        return;
    }
    console.log(data);
});
