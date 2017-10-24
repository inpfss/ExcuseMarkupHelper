"""
Get statistic of usage words in tactics
"""

# need in order to read correctly excuses file in UTF-8 encoding
import sys
# for writing file
import codecs

reload(sys)
sys.setdefaultencoding("utf-8")

# statistic class
# for splitting text into words
from nltk import word_tokenize
# import our helper class to access excuses data from XML tree
from excuses_helper import ExcusesHelper
# puctuation
import string

def safe_inc_for_key(dic, dic_key):
    if dic_key in dic:
        dic[dic_key] += 1
    else:
        dic[dic_key] = 1


def safe_get_value_for_key(dic, dic_key):
    if dic_key in dic:
        return dic[dic_key]
    else:
        return 0

# punctuations symbols for splitting text to words
punctuations = string.punctuation
# create instance of helper
excuseHelper = ExcusesHelper()

# statistic class
from nltk import ConditionalFreqDist
# list of interested words
interested_words_forms = ['apolog', 'sorry', 'regret', 'wrong', 'mistake', 'cause',
                    'sincerely', 'deeply', 'behalf', 'responsib', 'inappropriate', 'offen',
                    'offer', 'past', 'hurt', 'happend', 'understand', 'hope', 'insensitive',
                    'pain', 'better', 'sincere', 'unreservedly', 'fail', 'truly', 'forgive',
                    'intention', 'accept', 'feel', 'against', 'intended', 'respect',
                    'recogn', 'victim', 'truth', 'commit', 'consequenc', 'ask']

# get all defined tactic indices
tactic_indices = excuseHelper.get_defined_tactics_indices()
# dict with count of words that were used in tactics
word_count_dict = dict()
# statistic object for calculating usage words in tactics
tactics_words_dist = ConditionalFreqDist()

# iterate through all excuses
for tactic in excuseHelper.get_tactics_elements():
    # get tactic index
    tactic_index = int(tactic.attrib['tacticIndex'])
    # get text of this tactic element
    tactic_text = tactic.find('text').text
    # split text to words, skip punctuation, add them to list
    filtered_words = [word for word in word_tokenize(tactic_text.lower()) if word not in punctuations]
    # iterate through words
    for word in filtered_words:
        # iterate through interested words forms
        for interested_word_f in interested_words_forms:
            # current word is started as interested form of word
            if word.startswith(interested_word_f):
                # update total count of this word
                safe_inc_for_key(word_count_dict, word)
                # update count of this word for containing tactic text
                safe_inc_for_key(tactics_words_dist[tactic_index], word)

 # tabulate results
tactics_words_dist.tabulate()

# print total counts
for tactic_index in tactic_indices:
    print(tactics_words_dist[tactic_index])

sorted_words_list = sorted(word_count_dict.keys())
# write results to csv file
csv = codecs.open('words_statistic.csv', 'w',encoding='utf8')
csv.write('tacticId')
for word in sorted_words_list:
    csv.write(',"{0}"'.format(word))

for tactic_index in tactic_indices:
    csv.write('\n')
    csv.write('{0}'.format(tactic_index))
    for word in sorted_words_list:
        word_count_in_tactic = safe_get_value_for_key(tactics_words_dist[tactic_index], word)
        if word_count_in_tactic == 0:
            word_usage_percent = 0
        else:
            word_usage_percent = word_count_in_tactic * 100.0 / word_count_dict[word]
        csv.write(',{0}'.format(word_usage_percent))