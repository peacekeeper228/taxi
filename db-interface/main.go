package main

import (
	"context"
	"database/sql"
	"fmt"
	cat "gRPC"
	"log"
	"net"
	"tosql"

	"google.golang.org/grpc"
)

type myCatService struct {
	cat.UnimplementedTaxiServer
}

func (s *myCatService) GetCustomerByEmail(ctx context.Context, message *cat.EmailMessage) (*cat.BIOscetch, error) {

	DB, _ := tosql.OpenConnection()
	defer tosql.CloseConnection(DB)

	var firsname, lastname, patronymic string
	row := DB.QueryRow("SELECT firstname, lastname, patronymic FROM customers WHERE email=$1", message.Email)
	if err := row.Scan(&firsname, &lastname, &patronymic); err != nil {
		if err == sql.ErrNoRows {
			return nil, fmt.Errorf("CustomerByEmail %s: no such customer", message.Email)
		}
		return &cat.BIOscetch{}, fmt.Errorf("CustomerByEmail %s: %v", message.Email, err)
	}
	return &cat.BIOscetch{
		Firstname:  firsname,
		Lastname:   lastname,
		Patronymic: patronymic,
	}, nil
}

func (s *myCatService) GetDriverByEmail(ctx context.Context, message *cat.EmailMessage) (*cat.BIOscetch, error) {

	DB, _ := tosql.OpenConnection()
	defer tosql.CloseConnection(DB)

	var firsname, lastname, patronymic string
	row := DB.QueryRow("SELECT firstname, lastname, patronymic FROM drivers WHERE email=$1", message.Email)
	if err := row.Scan(&firsname, &lastname, &patronymic); err != nil {
		if err == sql.ErrNoRows {
			return nil, fmt.Errorf("DriverByEmail %s: no such driver", message.Email)
		}
		return &cat.BIOscetch{}, fmt.Errorf("DriverByEmail %s: %v", message.Email, err)
	}
	return &cat.BIOscetch{
		Firstname:  firsname,
		Lastname:   lastname,
		Patronymic: patronymic,
	}, nil
}

func (s *myCatService) GetCustomerEmail(ctx context.Context, message *cat.OrderNumber) (*cat.EmailMessage, error) {

	DB, _ := tosql.OpenConnection()
	defer tosql.CloseConnection(DB)

	var email string
	row := DB.QueryRow("SELECT customer FROM orders WHERE code=$1", message.Ordernumber)
	if err := row.Scan(&email); err != nil {
		if err == sql.ErrNoRows {
			return nil, fmt.Errorf("CustomerByOrder %s: no such order", message.Ordernumber)
		}
		return &cat.EmailMessage{}, fmt.Errorf("CustomerByOrder %s: %v", message.Ordernumber, err)
	}
	return &cat.EmailMessage{
		Email: email,
	}, nil
}

func (s *myCatService) GetDriverEmail(ctx context.Context, message *cat.OrderNumber) (*cat.EmailMessage, error) {

	DB, _ := tosql.OpenConnection()
	defer tosql.CloseConnection(DB)

	var email string
	row := DB.QueryRow("SELECT driver FROM orders WHERE code=$1", message.Ordernumber)
	if err := row.Scan(&email); err != nil {
		if err == sql.ErrNoRows {
			return nil, fmt.Errorf("DriverByOrder %s: no such order", message.Ordernumber)
		}
		return &cat.EmailMessage{}, fmt.Errorf("DriverByOrder %s: %v", message.Ordernumber, err)
	}
	return &cat.EmailMessage{
		Email: email,
	}, nil
}

func (s *myCatService) GetTicketInfo(ctx context.Context, message *cat.CodeNumber) (*cat.TicketMessage, error) {
	DB, _ := tosql.OpenConnection()
	defer tosql.CloseConnection(DB)

	var comment, tickettype, responsible, ticketorder string
	row := DB.QueryRow("SELECT comment, tickettype, responsible, ticketorder FROM suppporttickets WHERE code=$1", message.Code)
	if err := row.Scan(&comment, &tickettype, &responsible, &ticketorder); err != nil {
		if err == sql.ErrNoRows {
			return nil, fmt.Errorf("DriverByOrder %s: no such order", message.Code)
		}
		return &cat.TicketMessage{}, fmt.Errorf("DriverByOrder %s: %v", message.Code, err)
	}
	return &cat.TicketMessage{
		Comment:     comment,
		Tickettype:  tickettype,
		Responsible: responsible,
		Ticketorder: ticketorder,
	}, nil
}

func (s *myCatService) CreateCustomer(ctx context.Context, message *cat.BIOscetchWithEmail) (*cat.IndicatorMessage, error) {
	DB, _ := tosql.OpenConnection()
	defer tosql.CloseConnection(DB)

	_, err := DB.Exec("INSERT INTO customers (email, firstname, lastname, patronymic) VALUES ($1, $2, $3, $4)",
		message.Email,
		message.Firstname,
		message.Lastname,
		message.Patronymic)
	if err != nil {
		return &cat.IndicatorMessage{
			Indicator: false,
		}, fmt.Errorf("addCustomer: %v", err)
	}
	return &cat.IndicatorMessage{
		Indicator: true,
	}, nil
}

func (s *myCatService) CreateDriver(ctx context.Context, message *cat.BIOscetchWithEmail) (*cat.IndicatorMessage, error) {
	DB, _ := tosql.OpenConnection()
	defer tosql.CloseConnection(DB)

	_, err := DB.Exec("INSERT INTO drivers (email, firstname, lastname, patronymic) VALUES ($1, $2, $3, $4)",
		message.Email,
		message.Firstname,
		message.Lastname,
		message.Patronymic)
	if err != nil {
		return &cat.IndicatorMessage{
			Indicator: false,
		}, fmt.Errorf("addDriver: %v", err)
	}
	return &cat.IndicatorMessage{
		Indicator: true,
	}, nil
}

func (s *myCatService) CreateOrder(ctx context.Context, message *cat.OrderMessage) (*cat.IndicatorMessage, error) {
	DB, _ := tosql.OpenConnection()
	defer tosql.CloseConnection(DB)

	_, err := DB.Exec("INSERT INTO orders (Customer, Driver, Sourcelat, Sourcelng, Destlat, Destlng, Pathlength) VALUES ($1, $2, $3, $4, $5, $6, $7)",
		message.Customer,
		message.Driver,
		message.Sourcelat,
		message.Sourcelng,
		message.Destlat,
		message.Destlng,
		message.Pathlength)
	if err != nil {
		return &cat.IndicatorMessage{
			Indicator: false,
		}, fmt.Errorf("addDriver: %v", err)
	}
	return &cat.IndicatorMessage{
		Indicator: true,
	}, nil
}

func main() {
	port, err := net.Listen("tcp", ":1234")
	if err != nil {
		log.Println(err.Error())
		return
	}
	s := grpc.NewServer()
	cat.RegisterTaxiServer(s, &myCatService{})
	s.Serve(port)
	if err != nil {
		log.Fatalf("[x] serve: %v", err)
	}
	fmt.Printf("Initializing gRPC server on port %d", port)
}
