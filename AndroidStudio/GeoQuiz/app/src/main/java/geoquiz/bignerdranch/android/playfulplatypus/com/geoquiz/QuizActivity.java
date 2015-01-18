package geoquiz.bignerdranch.android.playfulplatypus.com.geoquiz;

import android.content.Intent;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;


public class QuizActivity extends ActionBarActivity {

    private Button mTrueButton;
    private Button mFalseButton;
    private ImageButton mNextButton;
    private Button mCheatButton;
    private TextView mQuestionTextView;
    private int mCurrentQuestion = 0;
    private boolean mIsACheater;
    private static final String TAG = "QuizActivity";
    private static final String KEY_INDEX = "index";
    private static final String KEY_IS_A_CHEATER = "is_a_cheater";

    private TrueFalse[] mQuestionBank = new TrueFalse[] {
            new TrueFalse(R.string.question1, true),
            new TrueFalse(R.string.question2, false),
            new TrueFalse(R.string.question3, false),
            new TrueFalse(R.string.question4, true),
            new TrueFalse(R.string.question5, true),
    };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Log.d(TAG, "onCreate(Bundle) called");
        setContentView(R.layout.activity_quiz);

        mQuestionTextView = (TextView)findViewById(R.id.question_textview);
        mTrueButton = (Button)findViewById(R.id.true_button);
        mTrueButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                scoreAnswer(true);
            }
        });
        mFalseButton = (Button)findViewById(R.id.false_button);
        mFalseButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                scoreAnswer(false);
            }
        });
        mNextButton = (ImageButton)findViewById(R.id.next_button);
        mNextButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                nextQuestion();
            }
        });
        mCheatButton = (Button)findViewById(R.id.cheat_button);
        mCheatButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(QuizActivity.this, CheatActivity.class);
                i.putExtra(CheatActivity.EXTRA_ANSWER_IS_TRUE, mQuestionBank[mCurrentQuestion].isAnswerTrue());
                startActivityForResult(i, 0);
            }
        });

        if (savedInstanceState != null) {
            mCurrentQuestion = savedInstanceState.getInt(KEY_INDEX, 0);
//            mIsACheater = savedInstanceState.getBoolean(KEY_IS_A_CHEATER, false);
        }
        displayQuestion();
    }

    @Override
    protected void onSaveInstanceState  (Bundle outState) {
        super.onSaveInstanceState(outState);
        outState.putInt(KEY_INDEX, mCurrentQuestion);
//        outState.putBoolean(KEY_INDEX, mIsACheater);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (data != null) {
            mIsACheater = data.getBooleanExtra(CheatActivity.EXTRA_DID_THEY_CHEAT, false);
            if (mIsACheater)
                mCheatButton.setEnabled(false);
        }
    }

    private void nextQuestion() {
        mCurrentQuestion = (mCurrentQuestion + 1) % mQuestionBank.length;
        displayQuestion();
    }

    private void displayQuestion() {
        mQuestionTextView.setText(mQuestionBank[mCurrentQuestion].getQuestion());
        mNextButton.setEnabled(false);
        mCheatButton.setEnabled(true);
        mIsACheater = false;
    }

    private void scoreAnswer(boolean b) {
        int messageID = 0;
        if (mIsACheater) {
            if (b == mQuestionBank[mCurrentQuestion].isAnswerTrue())
                messageID = R.string.judgement_toast_correct;
            else
                messageID = R.string.judgement_toast_incorrect;
        }
        else if (b == mQuestionBank[mCurrentQuestion].isAnswerTrue())
            messageID = R.string.correct_toast;
        else
            messageID = R.string.incorrect_toast;

        Toast.makeText(QuizActivity.this, messageID, Toast.LENGTH_SHORT).show();
        mNextButton.setEnabled(true);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_quiz, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

}
