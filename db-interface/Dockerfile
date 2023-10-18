FROM golang:1.21.1

COPY . /all

WORKDIR /all
RUN go work use .
RUN go build .

CMD ["go run ."]

EXPOSE 1234