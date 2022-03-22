const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors');
const app = express();
const mysql = require('mysql');

const db = mysql.createPool({
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'myschema'
});

//Middleware
app.use(cors());
app.use(express.json());
app.use(bodyParser.urlencoded({extended: true}));

//POST
app.post('/api/insert/employees', (req, res) => {

    const employeeNumber = req.body.employeeNumber;
    const lastName = req.body.lastName;
    const firstName = req.body.firstName;
    const extension = req.body.extension;
    const email = req.body.email;
    const officeCode = req.body.officeCode;
    const reportsTo = req.body.reportsTo;
    const jobTitle = req.body.jobTitle;

    const sqlInsert = "INSERT INTO `employees`(`employeeNumber`, `lastName`, `firstName`, `extension`, `email`, `officeCode`, `reportsTo`, `jobTitle`) VALUES (?,?,?,?,?,?,?,?)"
    db.query(sqlInsert, [employeeNumber, lastName, firstName, extension, email, officeCode, reportsTo, jobTitle], (err, result) => {

        if(err){
            console.log(err);
        }
        res.send(result);
    });
});

//PUT
app.put('/api/modify/employees', (req, res) => {

    const employeeNumber = req.body.employeeNumber;
    const email = req.body.email;


    const sqlInsert = "UPDATE employees SET email = ? WHERE employeeNumber = ?";
    db.query(sqlInsert, [email, employeeNumber], (err, result) => {

        if(err){
            console.log(err);
        }
        res.send(result);
    });
});


//GET
app.get('/api/get/employees', (req, res) => {

    const employeeNumber = req.body.employeeNumber;


    const sqlInsert = "SELECT * FROM employees WHERE employeeNumber = ?";
    db.query(sqlInsert, [employeeNumber], (err, result) => {

        if(err){
            console.log(err);
        }
        res.send(result);
    });
});


app.get('/', function (req, res) {
  res.send('Hello World!');
});
app.listen(3000, function () {
  console.log('Example app listening on port 3000!');
});