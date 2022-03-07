import tkinter
import tkinter.messagebox as tkmsg
import tkinter.simpledialog as simpledialog
from exceler import *
from PIL import Image, ImageTk
import math as m

one_page_limit_rate = 32*12
Oq = 3
mini = 4
frameR = 0
frameL = 0
fignumR = 0
fignumL = 0
scoreR = []
scoreL = []
keylist = [89,89,89,89,89]

for i in range(one_page_limit_rate):
    scoreR.append(keylist)
    scoreL.append(keylist)

#描画番号
tagR = 0
tagL = 0

# 画面作成
tki = tkinter.Tk()
tki.geometry('1280x650')
tki.title('Score Maker')

# 画像を表示するための準備
imgLi = []
for i in range(12):
    img = Image.open('picture/'+str(i+1)+'.png')
    if (i == 6) or (i == 7) or (i == 8):
        img = img.resize((50, 50))
    elif i == 11:
        img = img.resize((75, 75))
    else:
        img = img.resize((80, 80))
    imgLi.append(ImageTk.PhotoImage(img))

# 画像を表示するためのキャンバスの作成（黒で表示）
canvas = tkinter.Canvas(bg = "white", width=1280, height=650)
canvas.place(x=0, y=0) # 左上の座標を指定

# ラベル
lbl_1 = tkinter.Label(text='入力方法　音は英字で,#は音のあとに1,♭は2を入力')
lbl_1.place(x=50, y=2)
lbl_1 = tkinter.Label(text='オクターブ(three~mthree : 0 ~ 6) 初期値3   :   '+str(Oq))
lbl_1.place(x=325, y=2)
lbl_2= tkinter.Label(text='タイトル   :   ')
lbl_2.place(x=1040, y=2)
lbl_2= tkinter.Label(text='newScore')
lbl_2.place(x=1100, y=2)
lbl_3= tkinter.Label(text='hand   :   right hand')
lbl_3.place(x=575, y=2)
lbl_4= tkinter.Label(text='min   :   '+str(mini))
lbl_4.place(x=695, y=2)


#関数群

# clickイベント
#保存
def save():
    global lbl_2
    global scoreR
    global scoreL
    saveExcel(lbl_2["text"], scoreR,scoreL)

def btn_click():
    global lbl_2
    
    if (lbl_2["text"]=='') or (' ' in lbl_2["text"]) or ('\\' in lbl_2["text"]) or ('\"' in lbl_2["text"]) or ('[' in lbl_2["text"]) or (']' in lbl_2["text"]) or ('?' in lbl_2["text"]) or ('|' in lbl_2["text"]) or ('*' in lbl_2["text"]) or ('<' in lbl_2["text"]) or ('>' in lbl_2["text"]) or ('/' in lbl_2["text"]) or (':' in lbl_2["text"]):
        tkmsg.showwarning(title="警告", message="ゆるさない")
    elif tagL!=tagR:
        tkmsg.showwarning(title="警告", message="小節数が左右で異なります")
    else:
        if (tagL+1)%32 != 0:
            tkmsg.showwarning(title="警告", message="小節書ききってないです")
        else:
            save()
            tkmsg.showinfo("info","保存が完了しました")
    
def hand_click():
    global lbl_1
    global lbl_3
    global Oq

    if lbl_3["text"] == 'hand   :   right hand':
        Oq = 4
        lbl_3["text"] = 'hand   :   left hand'
    else:
        Oq = 3
        lbl_3["text"] = 'hand   :   right hand'
    lbl_1["text"] = 'オクターブ(three~mthree : 0 ~ 6) 初期値3   :   '+str(Oq)

def min_click():
    global lbl_4
    global mini
    
    inputdata4 = simpledialog.askstring("Change min", "何分音符かを入力してください",)
    n = mini
    if inputdata4 == "" or inputdata4 == None or not(inputdata4.isdigit()): inputdata4 = n
    mini = int(inputdata4)
    if mini != 1 and mini != 2 and mini != 3 and mini != 4 and mini != 8 and mini != 16:
        tkmsg.showwarning(title="警告", message="min違うよ")
        mini=n
    lbl_4["text"] = 'min   :   '+str(mini)

def title_click():
    global lbl_2
    
    inputdata2 = simpledialog.askstring("Change title", "titleを入力してください",)
    if inputdata2 == "" or inputdata2 == None: inputdata2 = ""
    lbl_2["text"] = inputdata2

def Oq_click():
    global lbl_1
    global Oq
    
    inputdata1 = simpledialog.askstring("Change Oq", "Oqを入力してください",)
    n = Oq
    if inputdata1 == "" or inputdata1 == None or not(inputdata1.isdigit()): inputdata1 = n
    Oq = int(inputdata1)
    if Oq < 0 or Oq > 6:
        tkmsg.showwarning(title="警告", message="Oq違うよ")
        Oq=n
    lbl_1["text"] = 'オクターブ(three~mthree : 0 ~ 6) 初期値3   :   '+str(Oq)

#Score maker
def key_click(keycode):
    global tagR
    global tagL
    global frameR
    global frameL
    global fignumR
    global fignumL

    #温風
    if mini < 4: keyKind = mini-1
    else: keyKind = 1+int(m.log2(mini))
    if keycode == 89:
        if (mini == 3)or(mini == 1)or(mini == 2):
            return;
        else:
            keyKind = 4+int(m.log2(mini))

    print(keyKind)

    #音階の違い
    deference = -keycode * 5
    if keycode == 89: deference = 0

    if(lbl_3["text"] == 'hand   :   right hand') :
        i = tagR
        deference += (Oq-3)*5*7
    else:
        i = tagL
        deference += (Oq-4)*5*7

    #分の幅の違い
    widDef = 0
    if keycode == 89: deference = 0

    if(lbl_3["text"] == 'hand   :   right hand') :
        i = tagR
        deference += (Oq-3)*5*7
    else:
        i = tagL
        deference += (Oq-4)*5*7
        
    if ((i<16)and(i>=0))or((i<80)and(i>=64))or((i<144)and(i>=128)):
        if(lbl_3["text"] == 'hand   :   right hand') :canvas.create_image(12+(i%64)*16, deference+(i//64)*200+75, image=imgLi[keyKind], anchor=tkinter.NW, tag = "onr_"+str(tagR))
        else :canvas.create_image(12+(i%64)*16, deference+(i//64)*200+130, image=imgLi[keyKind], anchor=tkinter.NW, tag = "onl_"+str(tagL))
    elif ((i<32)and(i>=16))or((i<96)and(i>=80))or((i<160)and(i>=144)):
        if(lbl_3["text"] == 'hand   :   right hand') :canvas.create_image(34+(i%64)*16, deference+(i//64)*200+75, image=imgLi[keyKind], anchor=tkinter.NW, tag = "onr_"+str(tagR))
        else :canvas.create_image(34+(i%64)*16, deference+(i//64)*200+130, image=imgLi[keyKind], anchor=tkinter.NW, tag = "onl_"+str(tagL))
    elif ((i<48)and(i>=32))or((i<112)and(i>=96))or((i<176)and(i>=160)):
        if(lbl_3["text"] == 'hand   :   right hand') :canvas.create_image(78+(i%64)*16, deference+(i//64)*200+75, image=imgLi[keyKind], anchor=tkinter.NW, tag = "onr_"+str(tagR))
        else :canvas.create_image(78+(i%64)*16, deference+(i//64)*200+130, image=imgLi[keyKind], anchor=tkinter.NW, tag = "onl_"+str(tagL))
    elif ((i<64)and(i>=48))or((i<128)and(i>=112))or((i<192)and(i>=176)):
        if(lbl_3["text"] == 'hand   :   right hand') :canvas.create_image(122+(i%64)*16, deference+(i//64)*200+75, image=imgLi[keyKind], anchor=tkinter.NW, tag = "onr_"+str(tagR))
        else :canvas.create_image(122+(i%64)*16, deference+(i//64)*200+130, image=imgLi[keyKind], anchor=tkinter.NW, tag = "onl_"+str(tagL))

    if(lbl_3["text"] == 'hand   :   right hand') :
        tagR+=1
        for i in range(mini):
            print("R:",keycode)
            scoreR[frameR+i][fignumR]
    else:
        tagL+=1
        for i in range(mini):
            print("L:",keycode)
            scoreL[frameL+i][fignumL]

    
def delete_click():
    global tagR
    global tagL
    if lbl_3["text"] == 'hand   :   right hand':
        if tagR == 0:
            pass
        else:
            canvas.delete("onr_"+str(tagR-1))
            tagR -= 1
    else:
        if tagL == 0:
            pass
        else:
            canvas.delete("onl_"+str(tagL-1))
            tagL -= 1

def delete_all_click():
    global tagR
    global tagL
    if lbl_3["text"] == 'hand   :   right hand':
        if tagR == 0:
            pass
        else:
            for i in range(tagR):
                canvas.delete("onr_"+str(i))
            tagR = 0
    else:
        if tagL == 0:
            pass
        else:
            for i in range(tagL):
                canvas.delete("onl_"+str(i))
            tagL = 0

#書き込み
def key(event):
    global frameR
    global frameL
    print("pressed", str(event.char))
    before = 0
    #ノーマル音
    if str(event.char) == 'c':
        print("code:",Oq*12+1)
        key_click(0)
        before = Oq*12+1
    elif str(event.char) == 'd':
        print("code:",Oq*12+3)
        key_click(1)
        before = Oq*12+3
    elif str(event.char) == 'e':
        print("code:",Oq*12+5)
        key_click(2)
        before = Oq*12+5
    elif str(event.char) == 'f':
        print("code:",Oq*12+6)
        key_click(3)
        before = Oq*12+6
    elif str(event.char) == 'g':
        print("code:",Oq*12+8)
        key_click(4)
        before = Oq*12+8
    elif str(event.char) == 'a':
        print("code:",Oq*12+10)
        key_click(5)
        before = Oq*12+10
    elif str(event.char) == 'b':
        print("code:",Oq*12+12)
        key_click(6)
        before = Oq*12+12
    
    elif str(event.char) == '1':
        print("code:","1is")
    elif str(event.char) == '2':
        print("code:",Oq*12+1)
    elif str(event.char) == 'n':
        print("code: rest")
        key_click(89)

    else:
        print("改行")
        print(scoreR,"\n",scoreL)
        frameR+=mini
        frameL+=mini
    

#五線譜
def notationCreater(baseLine):
    canvas.create_line(0, baseLine      , 1198, baseLine     , fill='black')
    canvas.create_line(0, baseLine + 10 , 1198, baseLine + 10, fill='black')
    canvas.create_line(0, baseLine + 20 , 1198, baseLine + 20, fill='black')
    canvas.create_line(0, baseLine + 30 , 1198, baseLine + 30, fill='black')
    canvas.create_line(0, baseLine + 40 , 1198, baseLine + 40, fill='black')
    canvas.create_line(300 , baseLine   , 300 , baseLine + 40, fill='black')#横
    canvas.create_line(600 , baseLine   , 600 , baseLine + 40, fill='black')
    canvas.create_line(900 , baseLine   , 900 , baseLine + 40, fill='black')
    canvas.create_line(1198, baseLine   , 1198, baseLine + 40, fill='black')
    canvas.create_image(-20,baseLine-20 , image=imgLi[10], anchor=tkinter.NW)#ト音
    
    
    baseLine = baseLine + 80
    canvas.create_line(0, baseLine      , 1198, baseLine     , fill='black')
    canvas.create_line(0, baseLine + 10 , 1198, baseLine + 10, fill='black')
    canvas.create_line(0, baseLine + 20 , 1198, baseLine + 20, fill='black')
    canvas.create_line(0, baseLine + 30 , 1198, baseLine + 30, fill='black')
    canvas.create_line(0, baseLine + 40 , 1198, baseLine + 40, fill='black')
    canvas.create_line(300 , baseLine   , 300 , baseLine + 40, fill='black')#横
    canvas.create_line(600 , baseLine   , 600 , baseLine + 40, fill='black')
    canvas.create_line(900 , baseLine   , 900 , baseLine + 40, fill='black')
    canvas.create_line(1198, baseLine   , 1198, baseLine + 40, fill='black')
    canvas.create_image(-20,baseLine-20 , image=imgLi[11], anchor=tkinter.NW)#ヘ音


# キャンバスに画像を表示する。第一引数と第二引数は、x, yの座標
#for i in range(10):
#    canvas.create_image(0, i*50, image=imgLi[i], anchor=tkinter.NW)

notationCreater(80)
notationCreater(280)
notationCreater(480)
    
# ボタン
btn = tkinter.Button(tki, text='保存', command=btn_click)
btn.place(x=1180, y=2)
btn = tkinter.Button(tki, text='one delete', command=delete_click)
btn.place(x=1205, y=50)
btn = tkinter.Button(tki, text='delete all', command=delete_all_click)
btn.place(x=1205, y=80)
btn = tkinter.Button(tki, text='Oq変更', command=Oq_click)
btn.place(x=770, y=2)
btn = tkinter.Button(tki, text='title変更', command=title_click)
btn.place(x=825, y=2)
btn = tkinter.Button(tki, text='hand変更', command=hand_click)
btn.place(x=885, y=2)
btn = tkinter.Button(tki, text='min変更', command=min_click)
btn.place(x=952, y=2)

tki.bind("<Key>", key)
tki.focus_set()

# 画面をそのまま表示
tki.mainloop()
