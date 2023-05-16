import numpy as np
import pandas as pd
from sklearn import tree
from sklearn.preprocessing import LabelEncoder

df = pd.read_csv('weather.csv')

y = df.iloc[:, -1]

columns = ['outlook', 'temperature', 'humidity', 'wind', 'play']
for a in columns:
    label = LabelEncoder()
    df[a] = label.fit_transform(df[a])

X = df.iloc[:, :-1]

clf = tree.DecisionTreeClassifier()
clf = clf.fit(X, y)
y_pred = clf.predict(X)
print(y_pred)



