import cv2

# tải file xml
xml = cv2.CascadeClassifier('haarcascade_frontalface_default.xml')
cap = cv2.VideoCapture(0)

while True:
    # chụp khung hình
    ret, frame = cap.read()
    # Các hoạt động trên khung
    gray = cv2.cvtColor(frame, 0)
    
    # hàm phát hiện khuôn mặt 
    # gray: là nguồn/bức ảnh xám.
    # scaleFactor: độ scale sau mỗi lần quét, tính theo 0.01 = 1%. Nếu như để scaleFactor = 1 thì tấm ảnh sẽ giữ nguyên
    # minNeighbors: scale và quét ảnh cho đến khi không thể scale được nữa thì lúc này sẽ xuất 
    # hiện những khung ảnh trùng nhau, số lần trùng nhau chính là tham số minNeighbors để quyết 
    # định cho việc có chọn khung ảnh này là khuôn mặt hay không.
    
    # faces = faceCascade.detectMultiScale(gray,scaleFactor = 1.1,minNeighbors = 5)
    phathien = xml.detectMultiScale(gray,scaleFactor=1.1,minNeighbors=5)
    if(len(phathien) > 0):
        (x,y,w,h) = phathien[0]
        frame = cv2.rectangle(frame,(x,y),(x+w,y+h),(0,255,0),3)

    # Display the resulting frame
    cv2.imshow('Hien khung',frame)
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break

# When everything done, release the capture
cap.release()
cv2.destroyAllWindows()