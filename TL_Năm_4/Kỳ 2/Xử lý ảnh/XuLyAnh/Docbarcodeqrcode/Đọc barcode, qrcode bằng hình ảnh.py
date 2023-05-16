import cv2

img = cv2.imread("D:\\XuLyAnh\\qr.png")
 
decoder = cv2.QRCodeDetector()
data, points, _ = decoder.detectAndDecode(img)
 
if points is not None:
    print('Dữ liệu được giải mã :' + data)
    points = points[0]
    for i in range(len(points)):
        pt1 = [int(val) for val in points[i]]
        pt2 = [int(val) for val in points[(i + 1) % 4]]
        cv2.line(img, pt1, pt2, color=(255, 0, 0), thickness=3)
cv2.imshow('Du lieu duoc giai ma ', img)
cv2.waitKey(0)
cv2.destroyAllWindows()
