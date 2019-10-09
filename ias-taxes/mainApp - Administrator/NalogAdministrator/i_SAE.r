library("R.matlab")
library("deepnet")
library("caret")
library("h2o")
library("TTR")
library("rminer")
library("foreach")
library("doParallel")
library("svSocket")
library("lattice")
library("ggplot2")
library("statmod")
library("kknn")
library("iterators")
library("parallel")
library("xlsx")
#install.packages("xlsx")

#dt <- Clearing(X, Y)


bar <- 5
left <- 0.8
right <- 0.2
n <- 30
h <- c(n)
LR <- 0.9
Ep <- 30
batch <- 50
dec <- 1
ratio <- 8/10
method <- "spatialSign"
mom <- 0.5
out <- "sigm"
sae <- "linear"

dt.b<-Balancing(dt)
X<-dt.b[ ,-ncol(dt.b)]
Y<-dt.b[ ,ncol(dt.b)]
t<-holdout(Y, ratio = ratio, mode = "random")
prepr<-preProcess(X[t$tr, ], method = method)
x.tr<-predict(prepr, X[t$tr, ])
x.ts<-predict(prepr, tail(X, bar))
y.tr<- Y[t$tr];
y.ts<-tail(Y, bar)

#x.tr<-data.matrix(x.tr)
#x.ts<-data.matrix(x.ts)
#y.tr<-data.matrix(y.tr)
#y.ts<-data.matrix(y.ts)

system.time(SAE<-sae.dnn.train(x= x.tr, y= y.tr, hidden=h, activationfun = "tanh", learningrate = LR, momentum = 0.5, learningrate_scale = 1.0, output = out, sae_output = sae, numepochs = Ep, batchsize = batch, hidden_dropout = 0, visible_dropout = 0))

Err<-Estimation(X<-dt.b[ ,-ncol(dt.b)], Y<-dt.b[ ,ncol(dt.b)], h=h, LR= LR, dec = dec, left=left, right=right, r=ratio, SAEf=SAE, isSAE=T)
Err

pr.sae<-nn.predict(SAE, x.ts)
summary(pr.sae)
pr<-ifelse(pr.sae>mean(pr.sae), 1, 0)
confusionMatrix(y.ts, pr)

#dt.x <- x.ts;
#dt.x <- tail(predict(prepr, dt[ ,-ncol(dt)]), n);
#dt.y <- tail(dt[ ,ncol(dt)], bar);
#pr.sae <- nn.predict(SAE, dt.x);
#pr <- ifelse(pr.sae > mean(pr.sae), 1, 0);
#Acc <<- unname(confusionMatrix(dt.y, pr)$overall[1]);
x <- X;
new.data <- predict(prepr, tail(x, bar));
pr.sae <- nn.predict(SAE, new.data);
if(dec == 1) {sig <<- ifelse(pr.sae > mean(pr.sae), -1, 1)}
if(dec == 2) {sig <<- ifelse(pr.sae > 0.8, -1, ifelse(pr.sae<0.2, 1, 0))}
dataResSig<-runBustSig(x,bar);
#write.xlsx(dataResSig, "c:/dataResSig.xlsx")