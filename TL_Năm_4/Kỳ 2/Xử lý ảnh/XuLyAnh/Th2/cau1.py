# #Trackbar tương phản, độ sáng
# import cv2
# img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")
# def changea(x):
#     changea.value = x
# changea.value = 0
# def changeb(x):
#     changeb.value = x
# changeb.value = 0

# cv2.namedWindow('xulyanh')
# cv2.createTrackbar('tuong phan','xulyanh', 1, 15, changea)
# cv2.createTrackbar('do sang','xulyanh', 0, 50, changeb)

# while(True):
#     alpha = changea.value
#     beta = changeb.value
#     img1 = cv2.convertScaleAbs(img,alpha = alpha, beta = beta)
#     cv2.imshow('xulyanh',img1)
#     if cv2.waitKey(5) == ord ('q'): break 
# cv2.destroyAllWindows()


# import cv2 as cv
# img = cv.imread("D:\\XuLyAnh\\sondeptrai.jpg")
# (h, w, d) = img.shape
# print('kich thuoc anh la: ')
# print("width={}, height={}, depth={}".format(w, h, d))


# print('diem mau toa do 200 va 300 la: ')
# (B, G, R) = img[100, 200]
# print("R={}, G={}, B={}".format(R, G, B))

# x = int(input('Nhap toa do x : '))
# y = int(input('Nhap toa do y : '))
# (B, R, G)=img[x , y]
# print('mau tai toa do đc nhap la:')
# print("R={},B={},G={}".format(R,G,B))

# a1 = int(input('Nhap toa do a1 : '))
# a2 = int(input('Nhap toa do a2 : '))
# a3 = int(input('Nhap toa do a3 : '))
# a4 = int(input('Nhap toa do a4 : '))
# anhcat = img[a1:a2, a3:a4]

# cv.imshow('Anh goc', img)
# cv.imshow('Anh cat', anhcat)
# cv.waitKey(0)
# cv.destroyAllWindows()

# import cv2
# import numpy as np
# img = cv2.imread("D:\\XuLyAnh\\hoahong.png")
# kernel = np.ones((5,5), np.uint8)
# img2 = cv2.dilate(img, kernel, iterations=1)
# cv2.imshow('Gian',img2)
# cn = cv2.Canny(img, 30, 200)
# contours, hierarchy = cv2.findContours(cn, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_NONE)
# cv2.drawContours(img, contours, -1, (0, 255, 0), 3)
# cv2.imshow('Contours', img)
# cv2.waitKey(0)
# cv2.destroyAllWindows()


import cv2

import matplotlib.pyplot as plt
# đọc ảnh
img = cv2.imread("D:\\XuLyAnh\\hoahong.png")
anhxam = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
anhmau = cv2.cvtColor(anhxam, cv2.COLOR_BGR2RGB)

a = int(input('Nhập độ sáng: '))
hien = cv2.convertScaleAbs(anhmau,a/10,3)

plt.subplot(2,2,1).axis('off'),plt.imshow(anhmau),plt.title('Ảnh xám')
plt.subplot(2,2,2).axis('off'),plt.imshow(hien),plt.title('Ảnh thay đổi độ sáng')

cv2.waitKey(0)
cv2.destroyAllWindows()














