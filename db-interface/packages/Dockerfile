FROM golang:1.21.1 
  
RUN apt-get update && apt-get install -y unzip  
  
# Install protobuf  
# @see https://github.com/yoshi42662/go-grpc/blob/master/server/Dockerfile  
RUN mkdir -p /tmp/protoc && \  
  curl -L https://github.com/protocolbuffers/protobuf/releases/download/v3.10.0/protoc-3.10.0-linux-x86_64.zip > /tmp/protoc/protoc.zip && \  
  cd /tmp/protoc && \  
  unzip protoc.zip && \  
  cp /tmp/protoc/bin/protoc /usr/local/bin && \  
  chmod go+rx /usr/local/bin/protoc && \  
  cd /tmp && \  
  rm -r /tmp/protoc  
  
WORKDIR /study-grpc  

COPY ./go.mod /
  
RUN go get -u google.golang.org/protobuf/cmd/protoc-gen-go
RUN go install google.golang.org/protobuf/cmd/protoc-gen-go

RUN go get -u google.golang.org/grpc/cmd/protoc-gen-go-grpc
RUN go install google.golang.org/grpc/cmd/protoc-gen-go-grpc

COPY . /study-grpc 
#RUN go get -u google.golang.org/grpc  
#RUN go get -u github.com/golang/protobuf/protoc-gen-go