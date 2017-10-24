'''
Які слова (sorry, apologize, mistake, responsibility, irresponsible, fail etc.)
є найбільш характерними для кожної комунікативної тактики
'''

import xml.etree.ElementTree as eT
from nltk.corpus.reader import XMLCorpusReader
import string
import nltk
from nltk.probability import FreqDist
from nltk import word_tokenize

punctuations = string.punctuation
reader = XMLCorpusReader('', 'ExcusesSample.xml')
root = eT.fromstring(reader.raw())

tacticsDict = dict()
for tactic in root.findall('./excuse/tactics/tactic'):
    tacticName = tactic.find('name').text
    tacticExcuse = tactic.find('text').text
    if not tacticName in tacticsDict.keys():
        tacticsDict[tacticName] = []
    tacticsDict[tacticName].append(tacticExcuse)

tactictsWordsFreq = dict()
for tacticName in tacticsDict:
    tacticExcusesMerged = ' '.join(tacticsDict[tacticName])
    tacticWords = [i for i in word_tokenize(tacticExcusesMerged) if i not in punctuations]
    tactictsWordsFreq[tacticName] = FreqDist(tacticWords)

for tacticName in tactictsWordsFreq:
    print(tacticName)
    print(tactictsWordsFreq[tacticName].max())
    tactictsWordsFreq[tacticName].plot()
