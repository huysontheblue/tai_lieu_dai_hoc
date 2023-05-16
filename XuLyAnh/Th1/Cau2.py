#In giá trị màu tại điểm nhập vào
import cv2 as cv
img = cv.imread("D:\\XuLyAnh\\sondeptrai.jpg")
x = int(input('Nhap toa do x : '))
y = int(input('Nhap toa do y : '))
(B, R, G)=img[x , y] 

print("R={},B={},G={}".format(R,G,B))
cv.imshow('Anh goc', img)
cv.waitKey(5000)
cv.destroyAllWindows()