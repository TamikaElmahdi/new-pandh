(window.webpackJsonp=window.webpackJsonp||[]).push([[6],{"+Ya6":function(n,t,e){"use strict";e.d(t,"a",(function(){return s}));var l=e("hrfs"),i=e("XNiG"),a=e("DDG+"),o=e("hSFZ"),s=function(){function n(n,t,e){var a=this;this.uow=n,this.mytranslate=t,this.dialog=e,this.obs=new i.a,this.showLegend=!0,this.withGraphe="100%",this.height="50vh",this.dataToShowInTable=[],this.title=null,this.arr2=new i.a,this.index=0,this.pieChartOptions={responsive:!0,maintainAspectRatio:!1,cutoutPercentage:50,title:{text:"",display:!0},tooltips:{enabled:!0,callbacks:{label:function(n,t){return t.labels[n.index]}}},hover:{mode:"nearest",intersect:!1,onHover:function(n,t){}},legend:{position:"bottom",display:!1,align:"center",labels:{fontSize:16}},plugins:{labels:{fontColor:["white","white","white","white","white","white","white","white","white","white","white","white"],precision:0,fontSize:14,fontStyle:"bold",render:"percentage"},pieceLabel:{render:function(n){var t=n.label,e=n.value;return a.arr2.next(n),t+": "+e}}}},this.pieChartLabels=[],this.pieChartData=[],this.pieChartType="pie",this.pieChartLegend=!0,this.pieChartPlugins=[o],this.pieChartColors=[{backgroundColor:[]}],this.list=[],this.retate=0,this.arr=[],Object(l.e)(),Object(l.d)()}return n.prototype.ngOnInit=function(){var n=this;this.pieChartOptions.legend.display=this.showLegend,this.obs.subscribe((function(t){n.title=t.title,n.pieChartLabels=t.chartLabels,n.pieChartData=t.chartData.map((function(n){return+n.toFixed(0)})),n.pieChartColors[0].backgroundColor=t.chartColors;var e=100-t.chartData.map((function(n){return+n.toFixed(0)})).reduce((function(n,t){return n+t}));e>10&&(n.pieChartLabels.push(""),n.pieChartData.push(e),n.pieChartColors[0].backgroundColor.push("#fff"),console.log("there is alot of space here",e)),n.dataToShowInTable=t.dataToShowInTable.map((function(n){return n})),n.count=t.count,n.arr=t.chartData.map((function(n,t){return t})),n.list=[],n.pieChartLabels.forEach((function(t,e){0!==n.pieChartData[e]&&n.list.push({name:t.toString(),value:n.pieChartData[e]})}))}))},n.prototype.openDialog=function(){this.dialog.open(a.a,{width:"7100px",disableClose:!1,data:{model:this.list,type:"pie",title:this.title}}).afterClosed().subscribe((function(n){console.log(n)}))},n.prototype.getColors=function(n){for(var t=["#d97f2a","#2d71a1","#c2c3c6","#ba6446","#7dc460","#fdb93a","#59b8ce","#5c5c5f","#ef4f42","#a5a6aa"],e=[],l=0;l<n;l++)e.push(t[l%t.length]);return e},n.prototype.toInt=function(n){return parseInt((n/3-1).toFixed(0),10)},n.prototype.toStr=function(n){return(parseInt(n.toFixed(0),10)*this.count/100).toFixed(0)},n}()},AT23:function(n,t,e){"use strict";var l=e("8Y7J"),i=e("hrfs"),a=e("SVse");e("oz3B"),e("7q3A"),e("J3i2"),e("s6ns"),e.d(t,"a",(function(){return o})),e.d(t,"b",(function(){return r}));var o=l.sb({encapsulation:0,styles:[["p[_ngcontent-%COMP%]{font-family:Lato}"]],data:{}});function s(n){return l.Qb(0,[(n()(),l.ub(0,0,null,null,3,"div",[["style","display: flex;margin-bottom: 7px;max-width: 50vw;width: 100%;"]],null,null,null,null,null)),(n()(),l.ub(1,0,null,null,1,"span",[["style","color: gray; font-size: 1em; margin: 0 10px;"]],null,null,null,null,null)),(n()(),l.Ob(2,null,["",""])),(n()(),l.ub(3,0,null,null,0,"div",[["style","width: 43px; height: 18px; border: 1px solid white;"]],[[4,"backgroundColor",null]],null,null,null,null))],null,(function(n,t){var e=t.component;n(t,2,0,t.context.$implicit),n(t,3,0,e.pieChartColors[0].backgroundColor[t.context.index])}))}function r(n){return l.Qb(0,[(n()(),l.ub(0,0,null,null,10,"div",[["class","d-flex flex-column align-items-center justify-content-center mb-3"],["style","cursor: pointer;"]],null,[[null,"click"]],(function(n,t,e){var l=!0;return"click"===t&&(l=!1!==n.component.openDialog()&&l),l}),null,null)),(n()(),l.ub(1,0,null,null,2,"div",[["style","display: block;"]],[[4,"width",null],[4,"height",null]],null,null,null,null)),(n()(),l.ub(2,0,null,null,1,"canvas",[["baseChart",""],["class","chart chart-pie"]],null,null,null,null,null)),l.tb(3,999424,null,0,i.a,[l.k,i.c],{data:[0,"data"],labels:[1,"labels"],options:[2,"options"],chartType:[3,"chartType"],colors:[4,"colors"],legend:[5,"legend"],plugins:[6,"plugins"]},null),(n()(),l.ub(4,0,null,null,2,"div",[["class","mt-3"]],null,null,null,null,null)),(n()(),l.jb(16777216,null,null,1,null,s)),l.tb(6,278528,null,0,a.l,[l.O,l.L,l.r],{ngForOf:[0,"ngForOf"]},null),(n()(),l.ub(7,0,null,null,3,"div",[["class","d-flex flex-column justify-content-center mt-2"]],null,null,null,null,null)),(n()(),l.ub(8,0,null,null,0,"img",[["height","10px"],["src","assets/line.png"],["width","280px"]],[[4,"transform",null]],null,null,null,null)),(n()(),l.ub(9,0,null,null,1,"h5",[["class","pie-title"],["style","color: #737473; margin: 5px 0 10px 5px;"]],null,null,null,null,null)),(n()(),l.Ob(10,null,[" "," "]))],(function(n,t){var e=t.component;n(t,3,0,e.pieChartData,e.pieChartLabels,e.pieChartOptions,e.pieChartType,e.pieChartColors,!0,e.pieChartPlugins),n(t,6,0,e.pieChartLabels)}),(function(n,t){var e=t.component;n(t,1,0,e.withGraphe,e.height),n(t,8,0,"rotateY("+e.retate+"deg)"),n(t,10,0,e.title)}))}},AyJq:function(n,t,e){"use strict";e.d(t,"a",(function(){return o})),e.d(t,"d",(function(){return r})),e.d(t,"b",(function(){return u})),e.d(t,"c",(function(){return c}));var l=e("8Y7J"),i=(e("c9fC"),e("SVse")),a=(e("5Bek"),e("zMNK")),o=(e("8bJo"),e("omvX"),e("5GAg"),l.sb({encapsulation:2,styles:[".mat-expansion-panel{box-sizing:content-box;display:block;margin:0;border-radius:4px;overflow:hidden;transition:margin 225ms cubic-bezier(.4,0,.2,1),box-shadow 280ms cubic-bezier(.4,0,.2,1)}.mat-accordion .mat-expansion-panel:not(.mat-expanded),.mat-accordion .mat-expansion-panel:not(.mat-expansion-panel-spacing){border-radius:0}.mat-accordion .mat-expansion-panel:first-of-type{border-top-right-radius:4px;border-top-left-radius:4px}.mat-accordion .mat-expansion-panel:last-of-type{border-bottom-right-radius:4px;border-bottom-left-radius:4px}@media (-ms-high-contrast:active){.mat-expansion-panel{outline:solid 1px}}.mat-expansion-panel._mat-animation-noopable,.mat-expansion-panel.ng-animate-disabled,.ng-animate-disabled .mat-expansion-panel{transition:none}.mat-expansion-panel-content{display:flex;flex-direction:column;overflow:visible}.mat-expansion-panel-body{padding:0 24px 16px}.mat-expansion-panel-spacing{margin:16px 0}.mat-accordion>.mat-expansion-panel-spacing:first-child,.mat-accordion>:first-child:not(.mat-expansion-panel) .mat-expansion-panel-spacing{margin-top:0}.mat-accordion>.mat-expansion-panel-spacing:last-child,.mat-accordion>:last-child:not(.mat-expansion-panel) .mat-expansion-panel-spacing{margin-bottom:0}.mat-action-row{border-top-style:solid;border-top-width:1px;display:flex;flex-direction:row;justify-content:flex-end;padding:16px 8px 16px 24px}.mat-action-row button.mat-button-base{margin-left:8px}[dir=rtl] .mat-action-row button.mat-button-base{margin-left:0;margin-right:8px}"],data:{animation:[{type:7,name:"bodyExpansion",definitions:[{type:0,name:"collapsed, void",styles:{type:6,styles:{height:"0px",visibility:"hidden"},offset:null},options:void 0},{type:0,name:"expanded",styles:{type:6,styles:{height:"*",visibility:"visible"},offset:null},options:void 0},{type:1,expr:"expanded <=> collapsed, void => collapsed",animation:{type:4,styles:null,timings:"225ms cubic-bezier(0.4,0.0,0.2,1)"},options:null}],options:{}}]}}));function s(n){return l.Qb(0,[(n()(),l.jb(0,null,null,0))],null,null)}function r(n){return l.Qb(2,[l.Mb(671088640,1,{_body:0}),l.Fb(null,0),(n()(),l.ub(2,0,[[1,0],["body",1]],null,5,"div",[["class","mat-expansion-panel-content"],["role","region"]],[[24,"@bodyExpansion",0],[1,"aria-labelledby",0],[8,"id",0]],[[null,"@bodyExpansion.done"]],(function(n,t,e){var l=!0;return"@bodyExpansion.done"===t&&(l=!1!==n.component._bodyAnimationDone.next(e)&&l),l}),null,null)),(n()(),l.ub(3,0,null,null,3,"div",[["class","mat-expansion-panel-body"]],null,null,null,null,null)),l.Fb(null,1),(n()(),l.jb(16777216,null,null,1,null,s)),l.tb(6,212992,null,0,a.c,[l.j,l.O],{portal:[0,"portal"]},null),l.Fb(null,2)],(function(n,t){n(t,6,0,t.component._portal)}),(function(n,t){var e=t.component;n(t,2,0,e._getExpandedState(),e._headerId,e.id)}))}var u=l.sb({encapsulation:2,styles:[".mat-expansion-panel-header{display:flex;flex-direction:row;align-items:center;padding:0 24px;border-radius:inherit}.mat-expansion-panel-header:focus,.mat-expansion-panel-header:hover{outline:0}.mat-expansion-panel-header.mat-expanded:focus,.mat-expansion-panel-header.mat-expanded:hover{background:inherit}.mat-expansion-panel-header:not([aria-disabled=true]){cursor:pointer}.mat-expansion-panel-header.mat-expansion-toggle-indicator-before{flex-direction:row-reverse}.mat-expansion-panel-header.mat-expansion-toggle-indicator-before .mat-expansion-indicator{margin:0 16px 0 0}[dir=rtl] .mat-expansion-panel-header.mat-expansion-toggle-indicator-before .mat-expansion-indicator{margin:0 0 0 16px}.mat-content{display:flex;flex:1;flex-direction:row;overflow:hidden}.mat-expansion-panel-header-description,.mat-expansion-panel-header-title{display:flex;flex-grow:1;margin-right:16px}[dir=rtl] .mat-expansion-panel-header-description,[dir=rtl] .mat-expansion-panel-header-title{margin-right:0;margin-left:16px}.mat-expansion-panel-header-description{flex-grow:2}.mat-expansion-indicator::after{border-style:solid;border-width:0 2px 2px 0;content:'';display:inline-block;padding:3px;transform:rotate(45deg);vertical-align:middle}"],data:{animation:[{type:7,name:"indicatorRotate",definitions:[{type:0,name:"collapsed, void",styles:{type:6,styles:{transform:"rotate(0deg)"},offset:null},options:void 0},{type:0,name:"expanded",styles:{type:6,styles:{transform:"rotate(180deg)"},offset:null},options:void 0},{type:1,expr:"expanded <=> collapsed, void => collapsed",animation:{type:4,styles:null,timings:"225ms cubic-bezier(0.4,0.0,0.2,1)"},options:null}],options:{}},{type:7,name:"expansionHeight",definitions:[{type:0,name:"collapsed, void",styles:{type:6,styles:{height:"{{collapsedHeight}}"},offset:null},options:{params:{collapsedHeight:"48px"}}},{type:0,name:"expanded",styles:{type:6,styles:{height:"{{expandedHeight}}"},offset:null},options:{params:{expandedHeight:"64px"}}},{type:1,expr:"expanded <=> collapsed, void => collapsed",animation:{type:3,steps:[{type:11,selector:"@indicatorRotate",animation:{type:9,options:null},options:{optional:!0}},{type:4,styles:null,timings:"225ms cubic-bezier(0.4,0.0,0.2,1)"}],options:null},options:null}],options:{}}]}});function p(n){return l.Qb(0,[(n()(),l.ub(0,0,null,null,0,"span",[["class","mat-expansion-indicator"]],[[24,"@indicatorRotate",0]],null,null,null,null))],null,(function(n,t){n(t,0,0,t.component._getExpandedState())}))}function c(n){return l.Qb(2,[(n()(),l.ub(0,0,null,null,3,"span",[["class","mat-content"]],null,null,null,null,null)),l.Fb(null,0),l.Fb(null,1),l.Fb(null,2),(n()(),l.jb(16777216,null,null,1,null,p)),l.tb(5,16384,null,0,i.m,[l.O,l.L],{ngIf:[0,"ngIf"]},null)],(function(n,t){n(t,5,0,t.component._showToggle())}),null)}},gct3:function(n,t,e){"use strict";e.d(t,"a",(function(){return l}));var l=function(){}},oz3B:function(n,t,e){"use strict";e.d(t,"a",(function(){return r}));var l=e("hrfs"),i=e("XNiG"),a=e("HDdC"),o=e("DDG+"),s=e("hSFZ"),r=function(){function n(n,t,e){this.uow=n,this.mytranslate=t,this.dialog=e,this.obs=new i.a,this.showLegend=!0,this.withGraphe="100%",this.positionLegendBottom=!1,this.canvasHeight=400,this.height="45vh",this.type=0,this.title=null,this.pieChartOptions={responsive:!0,maintainAspectRatio:!1,cutoutPercentage:50,title:{text:"",display:!0},tooltips:{enabled:!0},legend:{position:"bottom",display:!1,align:"center",fullWidth:!0,labels:{fontSize:16}},plugins:{labels:{fontColor:["white","white","white","white","white","white","white","white","white","white","white","white"],precision:0,render:"percentage",fontSize:14,fontStyle:"bold"},pieceLabel:{render:function(n){return n.label+": "+n.value}}}},this.pieChartLabels=[],this.pieChartData=[],this.pieChartType="pie",this.pieChartLegend=!0,this.pieChartPlugins=[s],this.pieChartColors=[{backgroundColor:[]}],this.list=[],this.retate=0,Object(l.e)(),Object(l.d)()}return n.prototype.ngOnInit=function(){var n=this;this.obs.subscribe((function(t){t.title instanceof a.a?t.title.subscribe((function(t){return n.title=t})):n.title=t.title,n.obs.subscribe((function(t){t.title instanceof a.a?t.title.subscribe((function(t){return n.title=t})):n.title=t.title,n.uow.realisations.genericByRecommendation(t.table,t.type,t.typeTable).subscribe((function(t){console.log(t),n.pieChartLabels=t.map((function(n){return n.table})),n.pieChartData=t.map((function(n){return+n.value.toFixed(0)})),n.pieChartColors[0].backgroundColor=n.getColors(n.pieChartLabels.length),n.pieChartLabels.forEach((function(e,l){0!==n.pieChartData[l]&&n.list.push({name:t[l].table.toString(),value:n.pieChartData[l]})}))}))}))}))},n.prototype.openDialog=function(){this.dialog.open(o.a,{width:"7100px",disableClose:!1,data:{model:this.list,type:"pie",title:this.title}}).afterClosed().subscribe((function(n){console.log(n)}))},n.prototype.getColors=function(n){for(var t=["#d97f2a","#2d71a1","#c2c3c6","#ba6446","#7dc460","#fdb93a","#59b8ce","#5c5c5f","#ef4f42","#a5a6aa"],e=[],l=0;l<n;l++)e.push(t[l%t.length]);return e},n}()},pRjZ:function(n,t,e){"use strict";e.d(t,"a",(function(){return a}));var l=e("8Y7J"),i=e("dFDH"),a=function(){var n=function(){function n(n){var t=this;this.snackBar=n,this.afterDismissed=function(){return t.snackBarRef.afterDismissed()},this.onAction=function(){return t.snackBarRef.onAction()},this.dismiss=function(){return t.snackBarRef.dismiss()}}return n.prototype.openMySnackBar=function(n,t){this.snackBarRef=this.snackBar.openFromComponent(o,{panelClass:["customClass"],data:n})},n.prototype.openSnackBar=function(n,t){void 0===t&&(t="close"),this.snackBarRef=this.snackBar.open(n,t,{duration:1e4})},n}();return n.ngInjectableDef=l.Ub({factory:function(){return new n(l.Vb(i.b))},token:n,providedIn:"root"}),n}(),o=function(n){this.data=n}},spq3:function(n,t,e){"use strict";var l=e("8Y7J"),i=e("hrfs");e("+Ya6"),e("7q3A"),e("J3i2"),e("s6ns"),e.d(t,"a",(function(){return a})),e.d(t,"b",(function(){return o}));var a=l.sb({encapsulation:0,styles:[['p[_ngcontent-%COMP%]{font-family:Lato}#customers[_ngcontent-%COMP%]{font-family:"Trebuchet MS",Arial,Helvetica,sans-serif;border-collapse:collapse;width:100%;text-align:center;font-size:x-small}#customers[_ngcontent-%COMP%]   td[_ngcontent-%COMP%], #customers[_ngcontent-%COMP%]   th[_ngcontent-%COMP%]{border:1px solid #ddd;padding:8px}#customers[_ngcontent-%COMP%]   tr[_ngcontent-%COMP%]:nth-child(even){background-color:#f2f2f2}#customers[_ngcontent-%COMP%]   tr[_ngcontent-%COMP%]:hover{background-color:#ddd}#customers[_ngcontent-%COMP%]   th[_ngcontent-%COMP%]{padding-top:12px;padding-bottom:12px;text-align:left;background-color:#aaabab;color:#fff}']],data:{}});function o(n){return l.Qb(0,[(n()(),l.ub(0,0,null,null,7,"div",[["class","d-flex flex-column align-items-center justify-content-center mb-3"],["style","cursor: pointer;"]],null,[[null,"click"]],(function(n,t,e){var l=!0;return"click"===t&&(l=!1!==n.component.openDialog()&&l),l}),null,null)),(n()(),l.ub(1,0,null,null,2,"div",[["style","display: block;"]],[[4,"width",null],[4,"height",null]],null,null,null,null)),(n()(),l.ub(2,0,null,null,1,"canvas",[["baseChart",""],["class","chart chart-pie"]],null,null,null,null,null)),l.tb(3,999424,null,0,i.a,[l.k,i.c],{data:[0,"data"],labels:[1,"labels"],options:[2,"options"],chartType:[3,"chartType"],colors:[4,"colors"],legend:[5,"legend"],plugins:[6,"plugins"]},null),(n()(),l.ub(4,0,null,null,3,"div",[["class","d-flex flex-column justify-content-center mt-2"]],null,null,null,null,null)),(n()(),l.ub(5,0,null,null,0,"img",[["height","10px"],["src","assets/line.png"],["width","280px"]],[[4,"transform",null]],null,null,null,null)),(n()(),l.ub(6,0,null,null,1,"h5",[["class","pie-title"],["style","color: #737473; margin: 5px 0 10px 5px;"]],null,null,null,null,null)),(n()(),l.Ob(7,null,[" "," "]))],(function(n,t){var e=t.component;n(t,3,0,e.pieChartData,e.pieChartLabels,e.pieChartOptions,e.pieChartType,e.pieChartColors,e.pieChartLegend,e.pieChartPlugins)}),(function(n,t){var e=t.component;n(t,1,0,e.withGraphe,e.height),n(t,5,0,"rotateY("+e.retate+"deg)"),n(t,7,0,e.title)}))}}}]);