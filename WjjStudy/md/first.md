#1.标题
---
标题1
=======
标题2
-----
#标题1
##标题2

#2.块注释 
--- 
>块注释
>       
>     块注释>4个空格

#3.强调
---
*强调斜体*
**强调加粗**
_强调斜体_
__强调加粗__

#4.列表
---

- 无序列表
- 无序列表
- 无序列表
	- fd
	- fd
>
1. 有序列表
2. 有序列表
3. 有序列表
	1. fd
	2. fd
	3. fd

#5.链接
---
内联方式：This is an [example link](http://example.com/).

引用方式：
I get 10 times more traffic from [Google][1] than from [Yahoo][2] or [MSN][3].  

[1]: http://google.com/        "Google" 
[2]: http://search.yahoo.com/  "Yahoo Search" 
[3]: http://search.msn.com/    "MSN Search"

#6.图片
---
图片的处理方式和链接的处理方式，非常的类似。

内联方式：
![alt text](http://su.bdimg.com/static/superpage/img/logo_white.png "Title")

引用方式：
![alt text][id] 
[id]: http://su.bdimg.com/static/superpage/img/logo_white.png "Title"

#7.代码
---
代码`code`

代码块
	
	fdsalkf

#8.脚注（footnote）
---

hello[^detail1]
hello[^detail2]

[^detail1]: detailpage1
[^detail2]: detailpage2

#9.下划线
---
用三个以上的星号、减号、底线来建立一个分隔线，行内不能有其他东西，中间可以插入空格。

***
* * *
---
- - -
___
_ _ _

#10.html标签

<a href="">xxx</a>

&copy;

4<5

#11.组合使用（前面加tab或空格）
*	A list item with a blockquote:

	> This is a blockquote
	> inside a list item.

		代码区块
		tell application "Foo"
			beep
		end tell

#12.C#语法支持
---
	```c#
		public void Foo(){
			System.
		}
    ```

