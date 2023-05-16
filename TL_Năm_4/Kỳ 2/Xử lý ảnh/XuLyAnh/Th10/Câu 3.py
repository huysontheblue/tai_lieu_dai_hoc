# 3. Thực hiện các biến đổi tiền xửlý ảnh cần thiết, tìm và vẽcontour của ảnh.

import cv2 as cv
img = cv.imread("D:\\XuLyAnh\\sondeptrai.jpg")
imgray = cv.cvtColor(img, cv.COLOR_BGR2GRAY)
ret, thresh = cv.threshold(imgray, 127, 255, 0)
contours, hierarchy = cv.findContours(thresh, cv.RETR_TREE, cv.CHAIN_APPROX_SIMPLE)
cv.drawContours(img, contours, -1, (0,255,0), 3)
cv.drawContours(img, contours, 3, (0,255,0), 3)
cnt = contours[4]
cv.drawContours(img, [cnt], 0, (0,255,0), 3)

cv.imshow("coin",img)

cv.waitKey(0)
cv.destroyAllWindows()