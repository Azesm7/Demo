package main

import (
	"database/sql"
	"fmt"
	"log"
	"net"
	"net/http"
	"net/rpc"

	_ "github.com/go-sql-driver/mysql"
)

type Database struct {
	DB *sql.DB
}

func main() {
	sessManager := NewSessManager()

	rpc.Register(sessManager)
	rpc.HandleHTTP()

	l, e := net.Listen("tcp", ":8081")
	if e != nil {
		log.Fatal("listen error:", e)
	}

	fmt.Println("starting server at :8081")
	http.Serve(l, nil)
}
