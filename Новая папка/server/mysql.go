package main

import (
	"database/sql"
	"fmt"

	_ "github.com/go-sql-driver/mysql"
)

func mysql() *Database {
	
	dsn := "root:Roman1125./@tcp(localhost:3306)/gostfil?"
	// указываем кодировку
	dsn += "&charset=utf8"
	// отказываемся от prapared statements
	// параметры подставляются сразу
	dsn += "&interpolateParams=true"
	db, err := sql.Open("mysql", dsn) // инициализирование бд
	if err != nil {
		fmt.Println("database not initialized")
	}
	db.SetMaxOpenConns(10)
	err = db.Ping() //первое подключение к базе
	if err != nil {
		fmt.Println("database MySql connection error")
	}
	Databases := &Database{
		DB: db,
	}
	return Databases
}
