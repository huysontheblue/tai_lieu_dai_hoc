# 3. Tạo trackbar để lấy kích thước cho kernel.
# - Sử dụng bộ lọc trung bình để lọc ảnh với kích thước bộ
# lọc lấy từ trackbar
# - Ấn phím Q để lưu lại ảnh kết quả

import cv2
img = cv2.imread("D:\\XuLyAnh\\hoahong2.png")
def get_d(vitri):
    get_d.value = vitri
get_d.value = 0
cv2.namedWindow('Trackbar')
cv2.createTrackbar('x', 'Trackbar', 0, 5, get_d)
while(True):
    a = get_d.value
    img1 = cv2.blur(img,(5,5))
    cv2.imshow('Trackbar', img1)
    if cv2.waitKey(5)==ord('q'):
        cv2.imwrite('D:\\XuLyAnh\\anhloctrungbinh.jpg', img1)
        break
cv2.destroyAllWindows()

# import cv2
# img = cv2.imread("D:\\XuLyAnh\\hoahong2.png")
# def get_x(vitri):
#     get_x.value = vitri
# def get_y(vitri):
#     get_y.value = vitri
# get_x.value = 1
# get_y.value = 1
# cv2.namedWindow('Trackbar')
# cv2.createTrackbar('x', 'Trackbar', 0, 5, get_x)
# cv2.createTrackbar('y', 'Trackbar', 0, 5, get_y)
# while(True):
#     a = get_x.value
#     b = get_y.value
#     img1 = cv2.blur(img, (a,b))
#     cv2.imshow('Trackbar', img1)
#     if cv2.waitKey(5)==ord('q'):
#         cv2.imwrite('E:\\boloc.jpg', img1)
#         break
# cv2.destroyAllWindows()