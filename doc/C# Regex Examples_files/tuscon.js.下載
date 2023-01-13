class HbCachedBid{defaultTimeoutSec=60*10;constructor(adunit,bidder,bidEvent,timeout=this.defaultTimeoutSec){this.adunit=adunit;this.bidder=bidder;this.bidEvent=bidEvent;this.timeout=timeout;this.cacheTime=Date.now();}
getAdUnit(){return this.adunit;}
getBidder(){return this.bidder;}
getBidEvent(){return this.bidEvent;}
hasTimedOut(){return this.timeout>0&&(Date.now()-this.cacheTime>1000*this.timeout)}
getComparisonMetric(){if(this.hasTimedOut()){return 0;}
let metric=this.bidEvent.cpm;if(typeof metric!=='undefined'){return metric;}
return 0;}
isBetterBidThan(cachedBid){if(cachedBid!==null&&typeof cachedBid==='object'&&typeof cachedBid.getComparisonMetric==='function'){return this.getComparisonMetric()>cachedBid.getComparisonMetric();}
return(this.getComparisonMetric()>0);}}
class PrebidBidCache{allBidderCodes=null;sessionStorageKey="epbjs_cache";debugMode=false;constructor(bidStore=window.sessionStorage,debugMode=false){this.bidStore=bidStore;this.getBidsFromStore();this.debugMode=debugMode;}
log(message){if(this.debugMode){console.log("::pbc::"+message);}}
getBidsFromStore(){this.log("fetched bids from store");let rawBids=this.bidStore.getItem(this.sessionStorageKey);if(typeof rawBids==='undefined'||rawBids===null){this.bids={};}else{this.bids=JSON.parse(rawBids);for(let adunit in this.bids){for(let bidder in this.bids[adunit]){this.bids[adunit][bidder]=Object.assign(new HbCachedBid,this.bids[adunit][bidder]);}}}
return this.bids;}
saveBids(){this.log("saved bids to store");this.bidStore.setItem(this.sessionStorageKey,JSON.stringify(this.bids));}
getTopBidEventForAdUnit(adunit){this.log("fetching top bid for "+JSON.stringify(adunit));let topBid=null;let bidderBids=this.getAllBidsForAdUnit(adunit);for(let bidder in bidderBids){if(bidderBids[bidder].isBetterBidThan(topBid)){topBid=bidderBids[bidder];}}
if(topBid===null){return null;}
return topBid.bidEvent;}
hasBidForAdUnit(adunit,bidder){let allBids=this.getAllBidsForAdUnit(adunit);return(typeof allBids!=='undefined'&&typeof allBids[bidder]!=='undefined')}
hasAnyBids(adunit){return Object.keys(this.getAllBidsForAdUnit(adunit)).length>0;}
getAllBidsForAdUnit(adunit){return this.bids[adunit];}
getCachedBiddersForAdUnit(adunit){let biddersObj=this.getAllBidsForAdUnit(adunit)||{};return Object.keys(biddersObj);}
clearBidForUnit(adunit,bidder){this.log("clearing bids for "+JSON.stringify(adunit)+" for "+JSON.stringify(bidder));let allBids=this.getAllBidsForAdUnit(adunit);if(this.hasBidForAdUnit(adunit,bidder)){delete allBids[bidder];this.saveBids();}}
setBidForAdUnit(adunit,bidder,bidEvent){this.log("setting bid for "+JSON.stringify(adunit)+" for "+JSON.stringify(bidder));if(bidEvent===null){return;}
let bidToSave=bidEvent;if(typeof bidToSave.isBetterBidThan!=='function'){bidToSave=new HbCachedBid(adunit,bidder,bidToSave,-1);}
this.bids[adunit]=this.getAllBidsForAdUnit(adunit)||{};this.bids[adunit][bidder]=bidToSave;this.saveBids();}
getBidForAdUnitBidder(adunit,bidder){return this.getAllBidsForAdUnit(adunit)[bidder];}
setHigherBidForAdUnit(adunit,bidder,bidEvent){this.log("Attempting to set higher bid for adunit "+JSON.stringify(adunit)+" for "+JSON.stringify(bidder));if(bidEvent===null){return;}
let bidToCheck=bidEvent;if(typeof bidEvent.isBetterBidThan!=='function'){bidToCheck=new HbCachedBid(adunit,bidder,bidEvent,-1);}
let isBetterBid=true;if(this.hasBidForAdUnit(adunit,bidder)){let currentBest=this.getBidForAdUnitBidder(adunit,bidder);isBetterBid=bidToCheck.isBetterBidThan(currentBest);}
if(isBetterBid){this.setBidForAdUnit(adunit,bidder,bidToCheck);}}}
if(typeof(epbjs)!=='undefined'&&typeof(epbjs.ezBidCache)==='undefined'){epbjs.ezBidCache=new PrebidBidCache(window.sessionStorage,false);}