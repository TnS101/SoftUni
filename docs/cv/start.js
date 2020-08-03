var PORT = process.env.PORT || 5000;
var express = require('express');
const path = require('path');
const router = express.Router();
const app = express();

const http = require('http');
const server = http.Server(app);

app.use(express.static(__dirname));
router.get('/', function(req, res) {
    res.sendFile(path.join(__dirname + '/cv.html'));
});

app.use('/', router);

server.listen(PORT, function() {
    console.log('Server running');
});