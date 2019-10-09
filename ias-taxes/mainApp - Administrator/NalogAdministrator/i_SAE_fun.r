#-----------------------------------------------------
In <- function(prc = price, startYear = 2006){
  
  prc <- ts(prc, start = startYear)
  In <- prc/lag(prc,-1)-1
  
  return(In)
}

#---------------------------------------------------
Out <- function(zz1,zz2){
  #РћРїСЂРµРґРµР»РёРј СЃРєРѕСЂРѕСЃС‚СЊ РёР·РјРµРЅРµРЅРёСЏ Р—РёРіР—Р°РіР°
  dz1 <- c(NA,diff(zz1))
  dz2 <- c(NA,diff(zz2))
  #РџРµСЂРµРєРѕРґРёСЂСѓРµРј СЃРєРѕСЂРѕСЃС‚СЊ РІ СЃРёРіРЅР°Р»С‹; 0 - Buy; 1 - Sell
  n <- 1:length(dz2)
  sig<-0
  for(i in n)
  {
    sig[i]=NA;
    if(
      !is.na(dz2[i])
    )
    {
      
      if(
        dz2[i] > 0
      )
      {
        sig[i] = 0;
      }
      
      if(
        dz2[i] < 0
      )
      {
        sig[i] = 1;
      }
    }
  }
  return(sig)
}

#----------------------------------
Clearing <- function(x, y){
  names(y) = c("y");
  dt <- cbind(x, y);
  dt <- na.omit(dt);
  return(dt)  
}
ZZ <- function(ch = 0.0020, pr = result){
  zag <- ZigZag(pr, change = ch, percent = F, retrace = F, lastExtreme = T)
  n <- 1:length(zag)
  #Заполняем предыдущие значения
  for(i in n) { if(is.na(zag[i])) zag[i] = zag[i-1];}

  return(zag)
}
#---------------------------------------
Cs <- function (...)
  as.character(sys.call())[-1]
#-------------------------------------------

GetRes <- function(){
  z <- evalServer(con, flag1)
  z <- isTRUE(z)

  if(z){sig <<- evalServer(con, sig)}
  return(z)
}
Balancing<-function(DT){
  #Вычисляем таблицу с количеством классов
  cl<-table(DT[ ,ncol(DT)]);
  #Если разбаланс меньше 15%, возвращаем исходную матрицу
  if(max(cl)/min(cl)<= 1.1) return(DT)
  #Иначе балансируем в большую сторону
  DT<-if(max(cl)/min(cl)> 1.1){ 
    upSample(x = DT[ ,-ncol(DT)],y = as.factor(DT[ , ncol(DT)]), yname = "Y")
  }
  #Преобразуем у (фактор) в число
  DT$Y<-as.numeric(DT$Y)
  #Перекодируем у из 1,2 в 0,1
  DT$Y<-ifelse(DT$Y == 1, 0, 1)
  #Преобразуем датафрейм в матрицу
  DT<-as.matrix(DT)
  return(DT);
}

Testing.3<-function(dt1, dt2, r = 8/10, m = "random", norm = "spatialSign",
                    h = c(10), act = "tanh", LR = 0.8, Mom = 0.5, 
                    out = "sigm", sae = "linear", Ep = 10, Bs = 50, 
                    pr = T, bar = 500, dec=1, left=0.6, right=0.4, SAEf=SAE, isSAE=false){
  X<-dt1[ ,-ncol(dt1)]
  Y<-dt1[ ,ncol(dt1)]
  t<-holdout(Y, ratio = r, mode = m)
  prepr<-preProcess(X[t$tr, ], method = norm)
  x.tr<-predict(prepr, X[t$tr, ])
  y.tr<- Y[t$tr];
  if(!isSAE)
  {
    SAE<-sae.dnn.train(x = x.tr , y = y.tr , hidden = h, 
                       activationfun = act,
                       learningrate = LR, momentum = Mom, 
                       output = out, sae_output = sae, 
                       numepochs = Ep, batchsize = Bs)
  }
  else
  {
    SAE<-SAEf
  }
  X<-dt2[ ,-ncol(dt2)]
  Y<-dt2[ ,ncol(dt2)]
  x.ts<-predict(prepr, tail(X, bar))
  y.ts<-tail(Y, bar)
  pr.sae<-nn.predict(SAE, x.ts)
  #Вариант +/- mean
  if(dec == 1) sig<-ifelse(pr.sae>mean(pr.sae), -1, 1)
  #Вариант 60/40
  if(dec == 2) sig<-ifelse(pr.sae>right, -1, ifelse(pr.sae<left, 1, 0))
  bal<-cumsum(tail(price[  ,'CO'], bar) * sig)
  sig.zz<-ifelse(y.ts == 0, 1,-1 )
  bal.zz<-cumsum(tail(price[  ,'CO'], bar) * sig.zz)
  if(pr) return(bal)
  if(!pr) return(bal.zz)
}

Estimation<-function(X, Y, r = 8/10, m = "random", norm = "spatialSign",
                     h = c(10), act = "tanh", LR = 0.8, dec=2, Mom = 0.5, 
                     out = "sigm", sae = "linear", Ep = 10, Bs = 50, 
                     CM=F, left=0.6, right=0.4, SAEf=SAE, isSAE=false){
  #Индексы тренировочного и тестового наборов
  t<-holdout(Y, ratio = r, mode = m)
  #Параметры препроцессинга
  prepr<-preProcess(X[t$tr,  ], method = norm)
  #Разделяем на train и test наборы с препроцессингом 
  x.tr<-predict(prepr, X[t$tr,  ])
  x.ts<-predict(prepr, X[t$ts,  ])
  y.tr<- Y[t$tr]; y.ts<- Y[t$ts]
  #Обучаем модель
  if(!isSAE)
  {
    SAE<-sae.dnn.train(x = x.tr , y = y.tr , hidden = h, 
                       activationfun = act,
                       learningrate = LR, momentum = Mom, 
                       output = out, sae_output = sae, 
                       numepochs = Ep, batchsize = Bs)
  }
  else
  {
    SAE<-SAEf
  }
  #Получаем предсказание по тестовому набору
  pr.sae<-nn.predict(SAE, x.ts)
  #Перекодируем его в сигналы 1,0
  #Вариант +/- mean
  if(dec == 1) sig<-ifelse(pr.sae>mean(pr.sae), -1, 1)
  #Вариант 60/40
  if(dec == 2) sig<-ifelse(pr.sae>right, -1, ifelse(pr.sae<left, 1, 0))
  #Вычисляем коэффициент Accuracy или ошибку классификации
  if(CM) err<-unname(confusionMatrix(y.ts, pr)$overall[1])
  if(!CM) err<-nn.test(SAE, x.ts, y.ts, mean(pr.sae))
  return(err)
}
error=function(e = NA)
{
  return(NA)
}
getResArr<-function(xf,n,chg=0.01)
{
  countCols <- 1:ncol(xf);
  factorsRes = data.frame();
  for(j in countCols)
  {
    #operation normal
    curValue = xf[nrow(xf),j];
    newt.data <- predict(prepr, tail(xf, n));
    prt.sae <- nn.predict(SAE, newt.data);
    curSig <- getLstResSig(prt.sae);
    isPlus = 0;
    isMinus=0;
    #operation plus
    xf[nrow(xf),j] = xf[nrow(xf),j] + chg;
    newt.data <- predict(prepr, tail(xf, n));
    prt.sae <- nn.predict(SAE, newt.data);
    sigtlst_plus <- getLstResSig(prt.sae);
    if(sigtlst_plus != curSig) isPlus=1;
    xf[nrow(xf),j] = xf[nrow(xf),j] - chg;
    #operation minus
    xf[nrow(xf),j] = xf[nrow(xf),j] - chg;
    newt.data <- predict(prepr, tail(xf, n));
    prt.sae <- nn.predict(SAE, newt.data);
    sigtlst_minus <- getLstResSig(prt.sae);
    if(sigtlst_minus != curSig) isMinus=1;
    xf[nrow(xf),j] = xf[nrow(xf),j] + chg;
    #save res
    newRow <- data.frame(name=factorsNames[j],Res_Opp_Plus=sigtlst_plus,Res_Opp_Minus=sigtlst_minus, Chg=chg, curValue=curValue, curSig=curSig, isChgPlus=isPlus,isChgMinus=isMinus);
    factorsRes <- rbind(factorsRes, newRow);
  }
  return(factorsRes);
}
getLstResSig<-function(prt.sae)
{
  if(dec == 1) {sigt <<- ifelse(prt.sae > mean(prt.sae), -1, 1)}
  if(dec == 2) {sigt <<- ifelse(prt.sae > 0.8, -1, ifelse(prt.sae<0.2, 1, 0))}
  return(sigt[nrow(sigt)]);
}
runBustSig<-function(xf,n)
{
  arrChg <-c(0.01,0.025,0.05,0.075,0.1,0.15,0.25,0.35,0.5,0.75,1,2,3,4,5);
  nChg <- 1:length(arrChg);
  dataSig<-data.frame();
  for(i in nChg)
  {
    resChg <- getResArr(xf,n,arrChg[i]);
    dataSig<-rbind(dataSig,resChg);
  }
  return(dataSig);
}