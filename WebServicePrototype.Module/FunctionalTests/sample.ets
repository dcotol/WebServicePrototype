;#DropDB WebServicePrototypeEasyTest

#Application WebServicePrototypeWin
;#Application WebServicePrototypeWeb
#IfDef WebServicePrototypeWin

*Action About...
 
*Action OK

#EndIf

#IfDef WebServicePrototypeWeb
!Action Navigation(My Details)
#EndIf
