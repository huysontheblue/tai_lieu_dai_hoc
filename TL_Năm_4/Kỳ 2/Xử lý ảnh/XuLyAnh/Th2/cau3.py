# Thu phóng ảnh với tỉ lệ nhập vào từ bàn phím
import cv2
img =cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")
fx = int(input('Nhap toa do fx: '))
fy = int(input('Nhap toa do fy: '))

# hàm thay đổi kích thước ảnh dùng để thu phóng ảnh
img1 = cv2.resize(img,(fx,fy),interpolation = cv2.INTER_LINEAR)
cv2.imshow('Anh ban dau',img)
cv2.imshow('Anh phong dai',img1)
cv2.waitKey(0)
cv2.destroyAllWindows()
