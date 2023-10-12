import socket
ip = '192.168.1.110'
port = 1983
s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
s.sendto(b'O\r\n', (ip, port))

