import cv2

img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")
r = cv2.selectROI(img)
imCrop = img[int(r[1]):int(r[1]+r[3]), int(r[0]):int(r[0]+r[2])]
cv2.imshow("Image", imCrop)
cv2.waitKey(0)
cv2.destroyAllWindows()