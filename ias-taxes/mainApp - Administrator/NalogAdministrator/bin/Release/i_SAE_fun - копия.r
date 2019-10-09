#-----------------------------------------------------
In <- function(prc = price, startYear = 2006){
  
  prc <- ts(prc, start = startYear)
  In <- prc/lag(prc,-1)-1
  
  return(In)
}
CleanMatrix <- function(mx){
  mx<-mx[, colSums(mx == 1) != nrow(mx)]
  mx<-mx[, colSums(mx == 0) != nrow(mx)]
  return(mx)
}
#---------------------------------------------------
Out <- function(zz1,zz2){
  #Определим скорость изменения ЗигЗага
  dz1 <- c(NA,diff(zz1))
  dz2 <- c(NA,diff(zz2))
  #Перекодируем скорость в сигналы; 0 - Buy; 1 - Sell
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
  x <- CleanMatrix(x);
  dt <- cbind(x, y);
  dt <- na.omit(dt);
  return(dt)  
}
ZZ <- function(ch = 0.0020, pr = result){
  zag <- ZigZag(pr, change = ch, percent = F, retrace = F, lastExtreme = T)
  n <- 1:length(zag)
  #��������� ���������� ��������
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
  #��������� ������� � ����������� �������
  cl<-table(DT[ ,ncol(DT)]);
  #���� ��������� ������ 15%, ���������� �������� �������
  if(max(cl)/min(cl)<= 1.1) return(DT)
  #����� ����������� � ������� �������
  DT<-if(max(cl)/min(cl)> 1.1){ 
    upSample(x = DT[ ,-ncol(DT)],y = as.factor(DT[ , ncol(DT)]), yname = "Y")
  }
  #����������� � (������) � �����
  DT$Y<-as.numeric(DT$Y)
  #������������ � �� 1,2 � 0,1
  DT$Y<-ifelse(DT$Y == 1, 0, 1)
  #����������� ��������� � �������
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
  #������� +/- mean
  if(dec == 1) sig<-ifelse(pr.sae>mean(pr.sae), -1, 1)
  #������� 60/40
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
  #������� �������������� � ��������� �������
  t<-holdout(Y, ratio = r, mode = m)
  #��������� ��������������
  prepr<-preProcess(X[t$tr,  ], method = norm)
  #��������� �� train � test ������ � ��������������� 
  x.tr<-predict(prepr, X[t$tr,  ])
  x.ts<-predict(prepr, X[t$ts,  ])
  y.tr<- Y[t$tr]; y.ts<- Y[t$ts]
  #������� ������
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
  #�������� ������������ �� ��������� ������
  pr.sae<-nn.predict(SAE, x.ts)
  #������������ ��� � ������� 1,0
  #������� +/- mean
  if(dec == 1) sig<-ifelse(pr.sae>mean(pr.sae), -1, 1)
  #������� 60/40
  if(dec == 2) sig<-ifelse(pr.sae>right, -1, ifelse(pr.sae<left, 1, 0))
  #��������� ����������� Accuracy ��� ������ �������������
  if(CM) err<-unname(confusionMatrix(y.ts, pr)$overall[1])
  if(!CM) err<-nn.test(SAE, x.ts, y.ts, mean(pr.sae))
  return(err)
}
error=function(e = NA)
{
  return(NA)
}
