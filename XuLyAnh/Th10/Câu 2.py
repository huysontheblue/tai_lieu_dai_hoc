# 2. Rê chuột cắt 1 vùng ảnh,có hiệu ứng giảm độ sáng của ảnh khi rê chuột. Lưulạiảnh vừa cắt
import cv2
# đọc ảnh
im = cv2.imread("E:\TL_Năm_4\Kỳ 2\Xử lý ảnh\XuLyAnh")
r = cv2.selectROI(im)
imCrop = im[int(r[1]):int(r[1]+r[3]), int(r[0]):int(r[0]+r[2])]
cv2.imshow("Image", imCrop)
#lưu ảnh
cv2.imwrite("D:\\XuLyAnh\\anhaukhicat.jpg", imCrop)
cv2.waitKey(5) == ord('Esc')
cv2.destroyAllWindows()

