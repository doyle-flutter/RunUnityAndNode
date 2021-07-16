const express = require('express'),
    app = express();
app.listen(3003);
app.get('/t1', (req,res) => res.json("Hi Unity"));
app.get('/t2', (req,res) => res.json(['안녕', '유니티']));
app.get('/t3', (req,res) => res.json({title: '제목', des: 'desss', date: '2021-07-16'}));
app.get('/t4', (req,res) => res.json({data: '데이타'}));

app.post('/t11', (req,res) => res.json("p,Hi Unity"));
app.post('/t22', (req,res) => res.json(['p,안녕', 'p,유니티']));
app.post('/t33', (req,res) => res.json({title: 'p,제목', des: 'p,desss', date: 'p,2021-07-16'}));
