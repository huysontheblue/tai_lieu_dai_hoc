# # bộ lọc gauss
# import cv2 as cv

# from matplotlib import pyplot as plt

# # Tải và lọc hình ảnh
# img = cv.imread("D:\\XuLyAnh\\hoahong.png")
# img2 = cv.imread("D:\\XuLyAnh\\hoahong2.png")
# # hàm lọc
# blur = cv.GaussianBlur(img,(5,5),0)
# blur2 = cv.GaussianBlur(img2,(5,5),0)

# # Chuyển đổi màu từ bgr (OpenCV mặc định) sang rgb
# img_rgb = cv.cvtColor(img, cv.COLOR_BGR2RGB)
# blur_rgb = cv.cvtColor(blur, cv.COLOR_BGR2RGB)
# img_rgb2 = cv.cvtColor(img2, cv.COLOR_BGR2RGB)
# blur_rgb2 = cv.cvtColor(blur2, cv.COLOR_BGR2RGB)

# plt.subplot(221),plt.imshow(img_rgb),plt.title('Anh 1')
# plt.xticks([]), plt.yticks([])
# plt.subplot(222),plt.imshow(blur_rgb),plt.title('Anh sau khi loc 1')
# plt.xticks([]), plt.yticks([])
# plt.subplot(223),plt.imshow(img_rgb2),plt.title('Anh 2')
# plt.xticks([]), plt.yticks([])
# plt.subplot(224),plt.imshow(blur_rgb2),plt.title('Anh sau khi loc 2')
# plt.xticks([]), plt.yticks([])
# plt.show()

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
