# Write a string (code) to punyforth TCP REPL server
import socket
ip = '192.168.1.110'
port = 1983
code = b'O\r\n'
s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
s.sendto(code, (ip, port))

