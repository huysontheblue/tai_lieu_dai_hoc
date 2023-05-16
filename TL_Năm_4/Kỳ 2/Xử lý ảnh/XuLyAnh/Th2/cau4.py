# Cắt 1 phần ảnh.
# import the necessary packages
import cv2
# load the image and show it
image = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")
cv2.imshow("original", image)
print(image)
# cắt ảnh 

cat = image[250:800, 250:600]
cv2.imshow("Anh cat", cat)
cv2.waitKey(0)


# cắt ảnh nhập vào từ bàn phím
# # Cắt 1 phần ảnh.
# # import the necessary packages
# import cv2
# # load the image and show it
# image = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")

# # cắt ảnh 
# x1 = int(input('Nhap x1: '))
# x2 = int(input('Nhap x2: '))
# y1 = int(input('Nhap y1: '))
# y2 = int(input('Nhap y2: '))

# cat = image[x1:x2, y1:y2]
# cv2.imshow("Anh goc", image)
# cv2.imshow("Anh cat", cat)
# cv2.waitKey(0)