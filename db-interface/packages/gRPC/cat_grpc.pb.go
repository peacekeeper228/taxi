// Code generated by protoc-gen-go-grpc. DO NOT EDIT.
// versions:
// - protoc-gen-go-grpc v1.3.0
// - protoc             v3.10.0
// source: gRPC/cat.proto

package gRPC

import (
	context "context"
	grpc "google.golang.org/grpc"
	codes "google.golang.org/grpc/codes"
	status "google.golang.org/grpc/status"
)

// This is a compile-time assertion to ensure that this generated file
// is compatible with the grpc package it is being compiled against.
// Requires gRPC-Go v1.32.0 or later.
const _ = grpc.SupportPackageIsVersion7

const (
	Taxi_GetCustomerByEmail_FullMethodName = "/Taxi/GetCustomerByEmail"
	Taxi_GetDriverByEmail_FullMethodName   = "/Taxi/GetDriverByEmail"
	Taxi_GetCustomerEmail_FullMethodName   = "/Taxi/GetCustomerEmail"
	Taxi_GetDriverEmail_FullMethodName     = "/Taxi/GetDriverEmail"
	Taxi_GetTicketInfo_FullMethodName      = "/Taxi/GetTicketInfo"
	Taxi_CreateCustomer_FullMethodName     = "/Taxi/CreateCustomer"
	Taxi_CreateDriver_FullMethodName       = "/Taxi/CreateDriver"
	Taxi_CreateOrder_FullMethodName        = "/Taxi/CreateOrder"
)

// TaxiClient is the client API for Taxi service.
//
// For semantics around ctx use and closing/ending streaming RPCs, please refer to https://pkg.go.dev/google.golang.org/grpc/?tab=doc#ClientConn.NewStream.
type TaxiClient interface {
	GetCustomerByEmail(ctx context.Context, in *EmailMessage, opts ...grpc.CallOption) (*BIOscetch, error)
	GetDriverByEmail(ctx context.Context, in *EmailMessage, opts ...grpc.CallOption) (*BIOscetch, error)
	GetCustomerEmail(ctx context.Context, in *OrderNumber, opts ...grpc.CallOption) (*EmailMessage, error)
	GetDriverEmail(ctx context.Context, in *OrderNumber, opts ...grpc.CallOption) (*EmailMessage, error)
	GetTicketInfo(ctx context.Context, in *CodeNumber, opts ...grpc.CallOption) (*TicketMessage, error)
	CreateCustomer(ctx context.Context, in *BIOscetchWithEmail, opts ...grpc.CallOption) (*IndicatorMessage, error)
	CreateDriver(ctx context.Context, in *BIOscetchWithEmail, opts ...grpc.CallOption) (*IndicatorMessage, error)
	CreateOrder(ctx context.Context, in *OrderMessage, opts ...grpc.CallOption) (*IndicatorMessage, error)
}

type taxiClient struct {
	cc grpc.ClientConnInterface
}

func NewTaxiClient(cc grpc.ClientConnInterface) TaxiClient {
	return &taxiClient{cc}
}

func (c *taxiClient) GetCustomerByEmail(ctx context.Context, in *EmailMessage, opts ...grpc.CallOption) (*BIOscetch, error) {
	out := new(BIOscetch)
	err := c.cc.Invoke(ctx, Taxi_GetCustomerByEmail_FullMethodName, in, out, opts...)
	if err != nil {
		return nil, err
	}
	return out, nil
}

func (c *taxiClient) GetDriverByEmail(ctx context.Context, in *EmailMessage, opts ...grpc.CallOption) (*BIOscetch, error) {
	out := new(BIOscetch)
	err := c.cc.Invoke(ctx, Taxi_GetDriverByEmail_FullMethodName, in, out, opts...)
	if err != nil {
		return nil, err
	}
	return out, nil
}

func (c *taxiClient) GetCustomerEmail(ctx context.Context, in *OrderNumber, opts ...grpc.CallOption) (*EmailMessage, error) {
	out := new(EmailMessage)
	err := c.cc.Invoke(ctx, Taxi_GetCustomerEmail_FullMethodName, in, out, opts...)
	if err != nil {
		return nil, err
	}
	return out, nil
}

func (c *taxiClient) GetDriverEmail(ctx context.Context, in *OrderNumber, opts ...grpc.CallOption) (*EmailMessage, error) {
	out := new(EmailMessage)
	err := c.cc.Invoke(ctx, Taxi_GetDriverEmail_FullMethodName, in, out, opts...)
	if err != nil {
		return nil, err
	}
	return out, nil
}

func (c *taxiClient) GetTicketInfo(ctx context.Context, in *CodeNumber, opts ...grpc.CallOption) (*TicketMessage, error) {
	out := new(TicketMessage)
	err := c.cc.Invoke(ctx, Taxi_GetTicketInfo_FullMethodName, in, out, opts...)
	if err != nil {
		return nil, err
	}
	return out, nil
}

func (c *taxiClient) CreateCustomer(ctx context.Context, in *BIOscetchWithEmail, opts ...grpc.CallOption) (*IndicatorMessage, error) {
	out := new(IndicatorMessage)
	err := c.cc.Invoke(ctx, Taxi_CreateCustomer_FullMethodName, in, out, opts...)
	if err != nil {
		return nil, err
	}
	return out, nil
}

func (c *taxiClient) CreateDriver(ctx context.Context, in *BIOscetchWithEmail, opts ...grpc.CallOption) (*IndicatorMessage, error) {
	out := new(IndicatorMessage)
	err := c.cc.Invoke(ctx, Taxi_CreateDriver_FullMethodName, in, out, opts...)
	if err != nil {
		return nil, err
	}
	return out, nil
}

func (c *taxiClient) CreateOrder(ctx context.Context, in *OrderMessage, opts ...grpc.CallOption) (*IndicatorMessage, error) {
	out := new(IndicatorMessage)
	err := c.cc.Invoke(ctx, Taxi_CreateOrder_FullMethodName, in, out, opts...)
	if err != nil {
		return nil, err
	}
	return out, nil
}

// TaxiServer is the server API for Taxi service.
// All implementations must embed UnimplementedTaxiServer
// for forward compatibility
type TaxiServer interface {
	GetCustomerByEmail(context.Context, *EmailMessage) (*BIOscetch, error)
	GetDriverByEmail(context.Context, *EmailMessage) (*BIOscetch, error)
	GetCustomerEmail(context.Context, *OrderNumber) (*EmailMessage, error)
	GetDriverEmail(context.Context, *OrderNumber) (*EmailMessage, error)
	GetTicketInfo(context.Context, *CodeNumber) (*TicketMessage, error)
	CreateCustomer(context.Context, *BIOscetchWithEmail) (*IndicatorMessage, error)
	CreateDriver(context.Context, *BIOscetchWithEmail) (*IndicatorMessage, error)
	CreateOrder(context.Context, *OrderMessage) (*IndicatorMessage, error)
	mustEmbedUnimplementedTaxiServer()
}

// UnimplementedTaxiServer must be embedded to have forward compatible implementations.
type UnimplementedTaxiServer struct {
}

func (UnimplementedTaxiServer) GetCustomerByEmail(context.Context, *EmailMessage) (*BIOscetch, error) {
	return nil, status.Errorf(codes.Unimplemented, "method GetCustomerByEmail not implemented")
}
func (UnimplementedTaxiServer) GetDriverByEmail(context.Context, *EmailMessage) (*BIOscetch, error) {
	return nil, status.Errorf(codes.Unimplemented, "method GetDriverByEmail not implemented")
}
func (UnimplementedTaxiServer) GetCustomerEmail(context.Context, *OrderNumber) (*EmailMessage, error) {
	return nil, status.Errorf(codes.Unimplemented, "method GetCustomerEmail not implemented")
}
func (UnimplementedTaxiServer) GetDriverEmail(context.Context, *OrderNumber) (*EmailMessage, error) {
	return nil, status.Errorf(codes.Unimplemented, "method GetDriverEmail not implemented")
}
func (UnimplementedTaxiServer) GetTicketInfo(context.Context, *CodeNumber) (*TicketMessage, error) {
	return nil, status.Errorf(codes.Unimplemented, "method GetTicketInfo not implemented")
}
func (UnimplementedTaxiServer) CreateCustomer(context.Context, *BIOscetchWithEmail) (*IndicatorMessage, error) {
	return nil, status.Errorf(codes.Unimplemented, "method CreateCustomer not implemented")
}
func (UnimplementedTaxiServer) CreateDriver(context.Context, *BIOscetchWithEmail) (*IndicatorMessage, error) {
	return nil, status.Errorf(codes.Unimplemented, "method CreateDriver not implemented")
}
func (UnimplementedTaxiServer) CreateOrder(context.Context, *OrderMessage) (*IndicatorMessage, error) {
	return nil, status.Errorf(codes.Unimplemented, "method CreateOrder not implemented")
}
func (UnimplementedTaxiServer) mustEmbedUnimplementedTaxiServer() {}

// UnsafeTaxiServer may be embedded to opt out of forward compatibility for this service.
// Use of this interface is not recommended, as added methods to TaxiServer will
// result in compilation errors.
type UnsafeTaxiServer interface {
	mustEmbedUnimplementedTaxiServer()
}

func RegisterTaxiServer(s grpc.ServiceRegistrar, srv TaxiServer) {
	s.RegisterService(&Taxi_ServiceDesc, srv)
}

func _Taxi_GetCustomerByEmail_Handler(srv interface{}, ctx context.Context, dec func(interface{}) error, interceptor grpc.UnaryServerInterceptor) (interface{}, error) {
	in := new(EmailMessage)
	if err := dec(in); err != nil {
		return nil, err
	}
	if interceptor == nil {
		return srv.(TaxiServer).GetCustomerByEmail(ctx, in)
	}
	info := &grpc.UnaryServerInfo{
		Server:     srv,
		FullMethod: Taxi_GetCustomerByEmail_FullMethodName,
	}
	handler := func(ctx context.Context, req interface{}) (interface{}, error) {
		return srv.(TaxiServer).GetCustomerByEmail(ctx, req.(*EmailMessage))
	}
	return interceptor(ctx, in, info, handler)
}

func _Taxi_GetDriverByEmail_Handler(srv interface{}, ctx context.Context, dec func(interface{}) error, interceptor grpc.UnaryServerInterceptor) (interface{}, error) {
	in := new(EmailMessage)
	if err := dec(in); err != nil {
		return nil, err
	}
	if interceptor == nil {
		return srv.(TaxiServer).GetDriverByEmail(ctx, in)
	}
	info := &grpc.UnaryServerInfo{
		Server:     srv,
		FullMethod: Taxi_GetDriverByEmail_FullMethodName,
	}
	handler := func(ctx context.Context, req interface{}) (interface{}, error) {
		return srv.(TaxiServer).GetDriverByEmail(ctx, req.(*EmailMessage))
	}
	return interceptor(ctx, in, info, handler)
}

func _Taxi_GetCustomerEmail_Handler(srv interface{}, ctx context.Context, dec func(interface{}) error, interceptor grpc.UnaryServerInterceptor) (interface{}, error) {
	in := new(OrderNumber)
	if err := dec(in); err != nil {
		return nil, err
	}
	if interceptor == nil {
		return srv.(TaxiServer).GetCustomerEmail(ctx, in)
	}
	info := &grpc.UnaryServerInfo{
		Server:     srv,
		FullMethod: Taxi_GetCustomerEmail_FullMethodName,
	}
	handler := func(ctx context.Context, req interface{}) (interface{}, error) {
		return srv.(TaxiServer).GetCustomerEmail(ctx, req.(*OrderNumber))
	}
	return interceptor(ctx, in, info, handler)
}

func _Taxi_GetDriverEmail_Handler(srv interface{}, ctx context.Context, dec func(interface{}) error, interceptor grpc.UnaryServerInterceptor) (interface{}, error) {
	in := new(OrderNumber)
	if err := dec(in); err != nil {
		return nil, err
	}
	if interceptor == nil {
		return srv.(TaxiServer).GetDriverEmail(ctx, in)
	}
	info := &grpc.UnaryServerInfo{
		Server:     srv,
		FullMethod: Taxi_GetDriverEmail_FullMethodName,
	}
	handler := func(ctx context.Context, req interface{}) (interface{}, error) {
		return srv.(TaxiServer).GetDriverEmail(ctx, req.(*OrderNumber))
	}
	return interceptor(ctx, in, info, handler)
}

func _Taxi_GetTicketInfo_Handler(srv interface{}, ctx context.Context, dec func(interface{}) error, interceptor grpc.UnaryServerInterceptor) (interface{}, error) {
	in := new(CodeNumber)
	if err := dec(in); err != nil {
		return nil, err
	}
	if interceptor == nil {
		return srv.(TaxiServer).GetTicketInfo(ctx, in)
	}
	info := &grpc.UnaryServerInfo{
		Server:     srv,
		FullMethod: Taxi_GetTicketInfo_FullMethodName,
	}
	handler := func(ctx context.Context, req interface{}) (interface{}, error) {
		return srv.(TaxiServer).GetTicketInfo(ctx, req.(*CodeNumber))
	}
	return interceptor(ctx, in, info, handler)
}

func _Taxi_CreateCustomer_Handler(srv interface{}, ctx context.Context, dec func(interface{}) error, interceptor grpc.UnaryServerInterceptor) (interface{}, error) {
	in := new(BIOscetchWithEmail)
	if err := dec(in); err != nil {
		return nil, err
	}
	if interceptor == nil {
		return srv.(TaxiServer).CreateCustomer(ctx, in)
	}
	info := &grpc.UnaryServerInfo{
		Server:     srv,
		FullMethod: Taxi_CreateCustomer_FullMethodName,
	}
	handler := func(ctx context.Context, req interface{}) (interface{}, error) {
		return srv.(TaxiServer).CreateCustomer(ctx, req.(*BIOscetchWithEmail))
	}
	return interceptor(ctx, in, info, handler)
}

func _Taxi_CreateDriver_Handler(srv interface{}, ctx context.Context, dec func(interface{}) error, interceptor grpc.UnaryServerInterceptor) (interface{}, error) {
	in := new(BIOscetchWithEmail)
	if err := dec(in); err != nil {
		return nil, err
	}
	if interceptor == nil {
		return srv.(TaxiServer).CreateDriver(ctx, in)
	}
	info := &grpc.UnaryServerInfo{
		Server:     srv,
		FullMethod: Taxi_CreateDriver_FullMethodName,
	}
	handler := func(ctx context.Context, req interface{}) (interface{}, error) {
		return srv.(TaxiServer).CreateDriver(ctx, req.(*BIOscetchWithEmail))
	}
	return interceptor(ctx, in, info, handler)
}

func _Taxi_CreateOrder_Handler(srv interface{}, ctx context.Context, dec func(interface{}) error, interceptor grpc.UnaryServerInterceptor) (interface{}, error) {
	in := new(OrderMessage)
	if err := dec(in); err != nil {
		return nil, err
	}
	if interceptor == nil {
		return srv.(TaxiServer).CreateOrder(ctx, in)
	}
	info := &grpc.UnaryServerInfo{
		Server:     srv,
		FullMethod: Taxi_CreateOrder_FullMethodName,
	}
	handler := func(ctx context.Context, req interface{}) (interface{}, error) {
		return srv.(TaxiServer).CreateOrder(ctx, req.(*OrderMessage))
	}
	return interceptor(ctx, in, info, handler)
}

// Taxi_ServiceDesc is the grpc.ServiceDesc for Taxi service.
// It's only intended for direct use with grpc.RegisterService,
// and not to be introspected or modified (even as a copy)
var Taxi_ServiceDesc = grpc.ServiceDesc{
	ServiceName: "Taxi",
	HandlerType: (*TaxiServer)(nil),
	Methods: []grpc.MethodDesc{
		{
			MethodName: "GetCustomerByEmail",
			Handler:    _Taxi_GetCustomerByEmail_Handler,
		},
		{
			MethodName: "GetDriverByEmail",
			Handler:    _Taxi_GetDriverByEmail_Handler,
		},
		{
			MethodName: "GetCustomerEmail",
			Handler:    _Taxi_GetCustomerEmail_Handler,
		},
		{
			MethodName: "GetDriverEmail",
			Handler:    _Taxi_GetDriverEmail_Handler,
		},
		{
			MethodName: "GetTicketInfo",
			Handler:    _Taxi_GetTicketInfo_Handler,
		},
		{
			MethodName: "CreateCustomer",
			Handler:    _Taxi_CreateCustomer_Handler,
		},
		{
			MethodName: "CreateDriver",
			Handler:    _Taxi_CreateDriver_Handler,
		},
		{
			MethodName: "CreateOrder",
			Handler:    _Taxi_CreateOrder_Handler,
		},
	},
	Streams:  []grpc.StreamDesc{},
	Metadata: "gRPC/cat.proto",
}
