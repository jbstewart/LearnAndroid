package geoquiz.bignerdranch.android.playfulplatypus.com.geoquiz;

import android.content.Intent;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;


public class CheatActivity extends ActionBarActivity {

    public static final String EXTRA_ANSWER_IS_TRUE = "com.playfulplatypus.bignerdranch.geoquiz.answer_is_true";
    public static final String EXTRA_DID_THEY_CHEAT = "com.playfulplatypus.bignerdranch.geoquiz.did_they_cheat";
    private static final String KEY_DID_THEY_CHEAT = "did_they_cheat";
    private boolean mIsAnswerTrue;
    private TextView mAnswerTextView;
    private Button mShowAnswerButton;
    private boolean mDidTheyCheat;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cheat);
        mIsAnswerTrue = getIntent().getBooleanExtra(EXTRA_ANSWER_IS_TRUE, false);
        mAnswerTextView = (TextView)findViewById(R.id.answerTextView);
        mShowAnswerButton = (Button)findViewById(R.id.showAnswerButton);
        mShowAnswerButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                ShowAnswer();
                SetCheatedResult(true);
            }
        });
        if (savedInstanceState != null)
        {
            mDidTheyCheat = savedInstanceState.getBoolean(KEY_DID_THEY_CHEAT, false);
            if (mDidTheyCheat)
                ShowAnswer();
        }
        SetCheatedResult(mDidTheyCheat);
    }

    private void ShowAnswer() {
        mAnswerTextView.setText(mIsAnswerTrue ? R.string.true_button : R.string.false_button);
    }

    @Override
    protected void onSaveInstanceState  (Bundle outState) {
        super.onSaveInstanceState(outState);
        outState.putBoolean(KEY_DID_THEY_CHEAT, mDidTheyCheat);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_cheat, menu);
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

    private void SetCheatedResult(boolean didTheyCheat) {
        mDidTheyCheat = didTheyCheat;
        Intent i = new Intent();
        i.putExtra(EXTRA_DID_THEY_CHEAT, didTheyCheat);
        setResult(RESULT_OK, i);
    }

}
