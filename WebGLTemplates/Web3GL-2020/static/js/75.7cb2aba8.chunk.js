(this.webpackJsonpweb3gl=this.webpackJsonpweb3gl||[]).push([[75],{503:function(n,e,r){"use strict";r.r(e);var t=r(10),o=r.n(t),u=(r(82),r(119));r(43),r(84),r(83);function i(n,e,r,t,o,u,i){try{var c=n[u](i),a=c.value}catch(s){return void r(s)}c.done?e(a):Promise.resolve(a).then(t,o)}function c(n){return function(){var e=this,r=arguments;return new Promise((function(t,o){var u=n.apply(e,r);function c(n){i(u,t,o,c,a,"next",n)}function a(n){i(u,t,o,c,a,"throw",n)}c(void 0)}))}}e.default=function(n){var e=n.apiKey,t=n.rpcUrl,i=n.networkId,a=n.preferred,s=n.label,f=n.iconSrc;return{name:s||"Fortmatic",svg:n.svg||'\n  <svg \n    height="40" \n    viewBox="0 0 40 40" \n    width="40" \n    xmlns="http://www.w3.org/2000/svg"\n  >\n    <path d="m2744.99995 1155h9.99997 10.00008v9.98139h-10.00008-9.99997-9.99998v9.9814.64001 9.28323.05815 9.9234h-9.99997v-9.9234-.05815-9.28323-.64001-9.9814-9.98139h9.99997zm9.99961 29.88552h-9.94167v-9.92324h19.93595v10.27235c0 2.55359-1.01622 5.00299-2.82437 6.80909-1.80867 1.8061-4.26182 2.82181-6.82018 2.82335h-.34973z" \n      fill="#617bff" \n      fill-rule="evenodd" \n      transform="translate(-2725 -1155)"/>\n  </svg>\n',iconSrc:f,wallet:function(){var n=c(o.a.mark((function n(a){var s,f,l,v,p,d,h;return o.a.wrap((function(n){for(;;)switch(n.prev=n.next){case 0:return n.next=2,r.e(85).then(r.t.bind(null,1289,7));case 2:return s=n.sent,f=s.default,l=new f(e,t?{chainId:i,rpcUrl:t}:1===i?void 0:Object(u.m)(i)),v=l.getProvider(),p=a.BigNumber,d=a.getAddress,n.abrupt("return",{provider:v,instance:l,interface:{name:"Fortmatic",connect:function(){return l.user.login().then((function(n){return h=!0,n}))},disconnect:function(){return l.user.logout()},address:{get:function(){return h?d(v):Promise.resolve()}},network:{get:function(){return Promise.resolve(i)}},balance:{get:function(){var n=c(o.a.mark((function n(){return o.a.wrap((function(n){for(;;)switch(n.prev=n.next){case 0:return n.abrupt("return",h&&l.user.getBalances().then((function(n){return n[0]?p(n[0].crypto_amount).times(p("1000000000000000000")).toString(10):null})));case 1:case"end":return n.stop()}}),n)})));return function(){return n.apply(this,arguments)}}()},dashboard:function(){return l.user.settings()}}});case 8:case"end":return n.stop()}}),n)})));return function(e){return n.apply(this,arguments)}}(),type:"sdk",desktop:!0,mobile:!0,preferred:a}}}}]);