package geoquiz.bignerdranch.android.playfulplatypus.com.geoquiz;

/**
 * Created by Brian.Stewart on 1/17/2015.
 */
public class TrueFalse {
    private int mQuestion;
    private boolean mAnswerIsTrue;

    public TrueFalse(int question, boolean isTrue) {
        mQuestion = question;
        mAnswerIsTrue = isTrue;
    }

    public int getQuestion() {
        return mQuestion;
    }

    public void setQuestion(int question) {
        mQuestion = question;
    }

    public boolean isAnswerTrue() {
        return mAnswerIsTrue;
    }

    public void setIsTrue(boolean isTrue) {
        mAnswerIsTrue = isTrue;
    }
}
