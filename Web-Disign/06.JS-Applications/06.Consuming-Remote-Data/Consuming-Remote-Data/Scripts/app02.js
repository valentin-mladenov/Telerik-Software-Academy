require.config({
	baseUrl: 'Scripts/libs',
	paths: {
		OAuth: 'oauth.min',
		jQurey: 'jquery-2.1.1.min'
	}
});

require(['../apps/02.Twitter-API']);